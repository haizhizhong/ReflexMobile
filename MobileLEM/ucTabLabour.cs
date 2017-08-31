using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MobileData;
using static WS_Popups.frmPopup;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.Diagnostics;
using DevExpress.XtraGrid.Columns;

namespace MobileLEM
{
    public partial class ucTabLabour : DevExpress.XtraEditors.XtraUserControl
    {
        LemLogHeader _headerRecord;

        class ColName
        {
            public const string Id = "Id";
            public const string EmpNum = "EmpNum";
            public const string EmployeeName = "EmployeeName";
            public const string WorkClass = "WorkClass";
            public const string Level1Code = "Level1Code";
            public const string Level2Code = "Level2Code";
            public const string Billable = "Billable";
            public const string TotalHours = "TotalHours";
            public const string BillAmount = "BillAmount";

            public const string BillRate = "BillRate";
            public const string EnterValue = "EnterValue";
        };

        public ucTabLabour()
        {
            InitializeComponent();
        }

        public void Init()
        {
            luColEmployee.DataSource = Employee.ListForCompany().Select(emp => new { EmpNum = emp.EmpNum, Name = emp.GetFullName() }).Distinct().ToList();

            var codeLevel1List = LevelOneCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Desc = code.Desc, FullDisplay = $"{code.MatchId}\t{code.Desc}" }).Distinct().ToList();
            codeLevel1List.Add(new { MatchId = -1, Desc = StringEx.TextUnknown, FullDisplay = "" });
            luColLevel1.DataSource = codeLevel1List.OrderBy(x => x.MatchId);

            var codeLevel2List = LevelTwoCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Desc = code.Desc, FullDisplay = $"{code.MatchId}\t{code.Desc}" }).Distinct().ToList();
            codeLevel2List.Add(new { MatchId = -1, Desc = StringEx.TextUnknown, FullDisplay = "" });
            luColLevel2All.DataSource = codeLevel2List.OrderBy(x => x.MatchId);

            Func<string, string, int, GridColumn> CreateColumn = new Func<string, string, int, GridColumn>( (field, caption, visibleIndex) => 
            {
                GridColumn column = gvLabour.Columns.AddVisible(field, caption);
                column.VisibleIndex = visibleIndex;
                return column;
            });

            int visionIndex = 0;
            new List<string> { ColName.EmpNum, ColName.EmployeeName, ColName.WorkClass, ColName.Level1Code, ColName.Level2Code, ColName.Billable}.ForEach( 
                x => gvLabour.Columns[x].VisibleIndex = visionIndex++
           );

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
            {
                tableLabour.Columns.Add($"{ColName.BillRate}{timecode.MatchId}", Type.GetType("System.Decimal"));
                var rateCol = CreateColumn($"{ColName.BillRate}{timecode.MatchId}", ColName.BillRate, visionIndex++);
                rateCol.DisplayFormat.FormatType = FormatType.Numeric;
                rateCol.DisplayFormat.FormatString = "c2";

                tableLabour.Columns.Add($"{ColName.EnterValue}{timecode.MatchId}", Type.GetType("System.Decimal"));
                var hourCol = CreateColumn($"{ColName.EnterValue}{timecode.MatchId}", timecode.Desc, visionIndex++);
                hourCol.ColumnEdit = textColHours;
            }

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
            {
                tableLabour.Columns.Add($"{ColName.EnterValue}{timecode.MatchId}", Type.GetType("System.Decimal"));
                var amountCol = CreateColumn($"{ColName.EnterValue}{timecode.MatchId}", timecode.Desc, visionIndex++);
                amountCol.ColumnEdit = textColAmount;
            }

            gvLabour.Columns[ColName.TotalHours].VisibleIndex = visionIndex++;
            gvLabour.Columns[ColName.BillAmount].VisibleIndex = visionIndex++;
        }

        public void SetModify(LemLogHeader header)
        {
            _headerRecord = header;
            SetEnabled();

            var pwc = ProjectWorkClass.ListForProject(_headerRecord.ProjectId).Select(x => x.WorkClassCode);
            var wcList = WorkClass.ListForCompany().Where(x => pwc.Contains(x.Code)).Select(wc => new { MatchId = wc.MatchId, Desc = wc.Desc }).Distinct().ToList();
            wcList.Insert(0, new { MatchId = -1, Desc = "" });
            luColWorkClass.DataSource = wcList;

            tableLabour.Clear();
            var list = LabourTimeEntry.GetLabourEntryList(header.Id).ToList();

            list.ForEach(lte =>
            {
                tableLabour.Rows.Add(
                 lte.Id,
                 lte.EmpNum,
                 Employee.GetEmployee(lte.EmpNum)?.GetFullName(),
                 lte.WorkClassId,
                 lte.Level1Id,
                 lte.Level2Id,
                 lte.Billable, 
                 lte.TotalHours,
                 lte.BillAmount);
            });

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
            {
                foreach (DataRow row in tableLabour.Rows)
                {
                    row[$"{ColName.BillRate}{timecode.MatchId}"] = (object)ProjectWorkClass.GetBillRate(_headerRecord.ProjectId, timecode.MatchId, (int)row[ColName.WorkClass]) ?? DBNull.Value;
                    row[$"{ColName.EnterValue}{timecode.MatchId}"] = (object)list.Find(x => x.Id == (int)row[ColName.Id]).DetailList.SingleOrDefault(d => d.TimeCodeId == timecode.MatchId)?.EnterValue ?? DBNull.Value;
                }
            }

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
            {
                foreach (DataRow row in tableLabour.Rows)
                {
                    row[$"{ColName.EnterValue}{timecode.MatchId}"] = (object)list.Find(x => x.Id == (int)row[ColName.Id]).DetailList.SingleOrDefault(d => d.TimeCodeId == timecode.MatchId)?.EnterValue ?? DBNull.Value;
                    row.AcceptChanges();
                }
            }

            tableLabour.AcceptChanges();
        }

        private void gvEmployee_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow row = gvLabour.GetDataRow(e.RowHandle);
            var project = Project.GetProject(_headerRecord.ProjectId);
            row[ColName.Billable] = project.Billable;
        }

        private void gvEmployee_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataRow row = gvLabour.GetDataRow(e.RowHandle);

            if (e.Column.FieldName == ColName.EmpNum)
            {
                row[ColName.EmployeeName] = Employee.GetEmployee((int)row[ColName.EmpNum])?.GetFullName();
                row[ColName.WorkClass] = Employee.GetEmployee((int)row[ColName.EmpNum])?.GetWorkClassId() ?? -1;
            }

            if (e.Column.FieldName == ColName.EmpNum || e.Column.FieldName == ColName.WorkClass)
            {
                foreach (var timeCode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
                {
//                    row[$"{ColName.BillRate}{timeCode.MatchId}"] = WorkClass.GetWorkClass((int)row[ColName.WorkClass]).HourlyBillRates[timeCode.MatchId];
                }
                CalcTotal(row);
            }

            if (e.Column.FieldName == ColName.Level1Code)
            {
                row[ColName.Level2Code] = -1;
            }

            if (e.Column.FieldName.Contains(ColName.EnterValue))
            {
                CalcTotal(row);
            }

            if (!gvLabour.IsNewItemRow(e.RowHandle))
            {
                if (new string[] { ColName.EmpNum, ColName.Level1Code , ColName.Level2Code, ColName.Billable,ColName.WorkClass}.Contains(e.Column.FieldName) || e.Column.FieldName.Contains(ColName.EnterValue))
                {
                    LabourTimeEntry.SqlUpdate((int)row[ColName.Id], (int)row[ColName.EmpNum], ConvertEx.ToNullable<int>(row[ColName.Level1Code]), ConvertEx.ToNullable<int>(row[ColName.Level2Code]),
                    (bool)row[ColName.Billable], (int)row[ColName.WorkClass], ConvertEx.ToNullable<decimal>(row[ColName.TotalHours]), ConvertEx.ToNullable<decimal>(row[ColName.BillAmount]));
                }

                if (e.Column.FieldName.Contains(ColName.EnterValue))
                {
                    LabourTimeDetail.SqlInsertUpdate((int)row[ColName.Id], int.Parse(e.Column.FieldName.Replace(ColName.EnterValue, "")), ConvertEx.ToNullable<decimal>(row[e.Column.FieldName]));
                }
            }
        }

        private void CalcTotal(DataRow row)
        {
            decimal totalHours = 0;
            decimal billAmount = 0;

            foreach (var timeCode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
            {
                if (row[$"{ColName.EnterValue}{timeCode.MatchId}"] != DBNull.Value)
                {
                    totalHours += Convert.ToDecimal(row[$"{ColName.EnterValue}{timeCode.MatchId}"]);
                    if (row[$"{ColName.BillRate}{timeCode.MatchId}"] != DBNull.Value)
                    {
                        billAmount += Convert.ToDecimal(row[$"{ColName.BillRate}{timeCode.MatchId}"]) * Convert.ToDecimal(row[$"{ColName.EnterValue}{timeCode.MatchId}"]);
                    }
                }
            }

            foreach (var timeCode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
            {
                if (row[$"{ColName.EnterValue}{timeCode.MatchId}"] != DBNull.Value)
                {
                    billAmount += Convert.ToDecimal(row[$"{ColName.EnterValue}{timeCode.MatchId}"]);
                }
            }

            row[ColName.TotalHours] = totalHours;
            row[ColName.BillAmount] = billAmount;
        }


        private void gvEmployee_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRow row = gvLabour.GetDataRow(e.RowHandle);
            if (row[ColName.EmpNum] == DBNull.Value || Convert.ToInt32(row[ColName.EmpNum]) <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Must select an Employee.";
                return;
            }
            if (row[ColName.WorkClass] == DBNull.Value || Convert.ToInt32(row[ColName.WorkClass]) <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Must select a WorkClass.";
                return;
            }

            if (row[ColName.Id] == DBNull.Value)
            {
                row[ColName.Id] = -1;
            }
        }

        private void gvEmployee_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == ColName.Level2Code)
            {
                DataRow row = gvLabour.GetDataRow(e.RowHandle);
                if (row != null)
                {
                    int level1Id = (int)row[ColName.Level1Code];
                    var codeList = LevelTwoCode.SubList(level1Id).Select(code => new { MatchId = code.MatchId, Desc = code.Desc, FullDisplay = $"{code.MatchId}\t{code.Desc}" }).Distinct().ToList();
                    codeList.Insert(0, new { MatchId = -1, Desc = StringEx.TextUnknown, FullDisplay = "" });
                    luColLevel2.DataSource = codeList.OrderBy(x => x.MatchId);
                    e.RepositoryItem = luColLevel2;
                }
            }
        }

        void SetEnabled()
        {
            gcLabour.Enabled = (_headerRecord.LogStatus == EnumLogStatus.Open);
        }

        public void LoadFromPrevDay()
        {
            if (LabourTimeEntry.CopyDataFromPrevDay(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetModify(_headerRecord);
            }
            else
            {
                Common.Popups.ShowPopup("The data of previous day is not available.");
            }
        }

        public void LoadFromTemplate()
        {
            if (LabourTimeEntry.CopyDataFromTemplate(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetModify(_headerRecord);
            }
            else
            {
                Common.Popups.ShowPopup("The data of template is not available.");
            }
        }

        private void gvLabour_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (Common.Popups.ShowPopup(this, "Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DataRow row = gvLabour.GetDataRow(e.RowHandle);
                LabourTimeEntry.SqlDelete((int)row[ColName.Id]);
            }
        }

        private void gvLabour_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (gvLabour.IsNewItemRow(e.RowHandle))
            {
                DataRowView row = e.Row as DataRowView;
                row[ColName.Id] = LabourTimeEntry.SqlInsert(_headerRecord.Id, (int)row[ColName.EmpNum], ConvertEx.ToNullable<int>(row[ColName.Level1Code]), ConvertEx.ToNullable<int>(row[ColName.Level2Code]),
                    (bool)row[ColName.Billable], (int)row[ColName.WorkClass], ConvertEx.ToNullable<decimal>(row[ColName.TotalHours]), ConvertEx.ToNullable<decimal>(row[ColName.BillAmount]));

                foreach (var timecode in TimeCode.ListForCompany())
                {
                    LabourTimeDetail.SqlInsert((int)row[ColName.Id], timecode.MatchId, ConvertEx.ToNullable<decimal>(row[$"{ColName.EnterValue}{timecode.MatchId}"]));
                }
            }
        }
    }
}
