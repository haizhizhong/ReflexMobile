using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MobileData;
using static WS_Popups.frmPopup;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using static MobileData.TimeCode;
using DevExpress.XtraEditors;
using ReflexCommon;

namespace MobileLEM
{
    public partial class ucLabourEntry : DevExpress.XtraEditors.XtraUserControl
    {
        LemHeader _headerRecord;

        const string strBillRate = "BillRate";
        const string strEnterHours = "EnterHours";
        const string strEnterAmount = "EnterAmount";

        public static string BillRateI(TimeCode code)
        {
            return $"{strBillRate}{code.MatchId}";
        }

        public static string EnterHoursI(TimeCode code)
        {
            return $"{strEnterHours}{code.MatchId}";
        }
        public static string EnterHoursI(int val)
        {
            return $"{strEnterHours}{val}";
        }

        public static string EnterAmountI(TimeCode code)
        {
            return $"{strEnterAmount}{code.MatchId}";
        }

        public ucLabourEntry()
        {
            InitializeComponent();

            luColEmpNum.DataSource = Employee.ListForCompany().Select(emp => new { EmpNum = emp.EmpNum, DisplayName = emp.DisplayName }).Distinct().ToList();
            luColEmpName.DataSource = Employee.ListForCompany().Select(emp => new { EmpNum = emp.EmpNum, DisplayName = emp.DisplayName }).Distinct().ToList();

            var wcList = WorkClass.ListForCompany().Select(wc => new { Code = wc.Code, DisplayName = wc.DisplayName }).Distinct().ToList();
            luColWorkClass.DataSource = wcList;

            var codeLevel1List = LevelOneCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel1All.DataSource = codeLevel1List.OrderBy(x => x.MatchId);

            var codeLevel2List = LevelTwoCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel2All.DataSource = codeLevel2List.OrderBy(x => x.MatchId);

            var level3CodeList = LevelThreeCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel3All.DataSource = level3CodeList.OrderBy(x => x.MatchId);

            var level4CodeList = LevelFourCode.ListForCompany().Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
            luColLevel4All.DataSource = level4CodeList.OrderBy(x => x.MatchId);

            Func<string, string, int, GridColumn> CreateColumn = new Func<string, string, int, GridColumn>((field, caption, visibleIndex) =>
            {
                GridColumn column = gvLabour.Columns.AddVisible(field, caption);
                column.VisibleIndex = visibleIndex;
                return column;
            });

            int visionIndex = 0;
            new List<GridColumn> { colEmpNum, colEmployeeName, colWorkClass, colChangeOrder, colLevel1Code, colLevel2Code, colLevel3Code, colLevel4Code, colBillable, colManual }
                .ForEach(x => x.VisibleIndex = visionIndex++);

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
            {
                tableLabour.Columns.Add(BillRateI(timecode), Type.GetType("System.Decimal"));
                var rateCol = CreateColumn(BillRateI(timecode), $"{timecode.Desc} Bill Rate", visionIndex++);
                rateCol.DisplayFormat.FormatType = FormatType.Numeric;
                rateCol.DisplayFormat.FormatString = "c2";
                rateCol.OptionsColumn.AllowEdit = false;

                tableLabour.Columns.Add(EnterHoursI(timecode), Type.GetType("System.Decimal"));
                var hourCol = CreateColumn(EnterHoursI(timecode), $"{timecode.Desc} Hours", visionIndex++);
                hourCol.ColumnEdit = textColHours;
                hourCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, hourCol.FieldName, "{0:n2}")});
            }

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
            {
                tableLabour.Columns.Add(EnterAmountI(timecode), Type.GetType("System.Decimal"));
                var amountCol = CreateColumn(EnterAmountI(timecode), timecode.Desc, visionIndex++);
                amountCol.ColumnEdit = textColAmount;
            }

            colTotalHours.VisibleIndex = visionIndex++;
            colBillAmount.VisibleIndex = visionIndex++;

            int maxLevel = Company.GetCurrCompany().MaxLevelCode;
            var SetColumn = new Action<GridColumn, int, string>((col, level, caption) =>
            {
                col.Visible = maxLevel >= level;
                col.OptionsColumn.ShowInCustomizationForm = maxLevel >= level;
                col.Caption = caption;
            });

            SetColumn(colLevel4Code, 4, Company.GetCurrCompany().Level4CodeDesc);
            SetColumn(colLevel3Code, 3, Company.GetCurrCompany().Level3CodeDesc);
            SetColumn(colLevel2Code, 2, Company.GetCurrCompany().Level2CodeDesc);
            SetColumn(colLevel1Code, 1, Company.GetCurrCompany().Level1CodeDesc);
        }

        public void SetCurrent(LemHeader header)
        {
            _headerRecord = header;
            SetEnabled(_headerRecord.CheckEditable());

            var changeOrderList = ChangeOrder.ListForProject(_headerRecord.ProjectId).Select(cs => new { EstimateId = cs.EstimateId, DisplayName = cs.DisplayName }).Distinct().ToList();
            changeOrderList.Add(new { EstimateId = -1, DisplayName = "" });
            luChangeOrder.DataSource = changeOrderList;

            tableLabour.Clear();
            var list = LabourTimeEntry.GetLabourEntryList(header.Id).ToList();

            list.ForEach(lte =>
            {
                DataRow row = tableLabour.Rows.Add(
                 lte.Id,
                 lte.EmpNum,
                 lte.EmpNum,
                 lte.WorkClassCode,
                 lte.ChangeOrderId,
                 lte.Level1Id,
                 lte.Level2Id,
                 lte.Level3Id,
                 lte.Level4Id,
                 lte.Billable,
                 lte.Manual,
                 lte.IncludedHours,
                 lte.TotalHours,
                 lte.BillAmount);

                foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
                {
                    row[BillRateI(timecode)] = (object)ProjectWorkClass.GetBillRate(_headerRecord.ProjectId, timecode.MatchId, (string)row[colWorkClass.FieldName]) ?? DBNull.Value;
                    row[EnterHoursI(timecode)] = (object)list.Find(x => x.Id == (int)row[colId.FieldName]).DetailList.SingleOrDefault(d => d.TimeCodeId == timecode.MatchId)?.WorkHours ?? DBNull.Value;
                }

                foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
                {
                    row[EnterAmountI(timecode)] = (object)list.Find(x => x.Id == (int)row[colId.FieldName]).DetailList.SingleOrDefault(d => d.TimeCodeId == timecode.MatchId)?.Amount ?? DBNull.Value;
                }
            });

            tableLabour.AcceptChanges();
            gvLabour.BestFitColumns(true);
        }

        private void gvEmployee_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow row = gvLabour.GetDataRow(e.RowHandle);
            var project = Project.GetProject(_headerRecord.ProjectId);
            row[colBillable.FieldName] = project.Billable;
            row[colManual.FieldName] = false;

            gvLabour.FocusedColumn = gvLabour.Columns.First( x=> x.Visible);
        }

        private void gvEmployee_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataRow row = gvLabour.GetDataRow(e.RowHandle);
            bool needSave = false;

            if (e.Column == colEmpNum || e.Column == colEmployeeName)
            {
                int enmNum = (int)row[e.Column.FieldName];
                row[colEmpNum.FieldName] = enmNum;
                row[colEmployeeName.FieldName] = enmNum;

                var wc = LabourTemplate.GetWorkClass(_headerRecord.ProjectId, enmNum, _headerRecord.LogDate);
                row[colWorkClass.FieldName] = wc ?? (object)Employee.GetEmployee(enmNum)?.WorkClassCode ?? DBNull.Value;
                needSave = true;
            }

            if (e.Column == colEmpNum || e.Column == colEmployeeName || e.Column == colWorkClass)
            {
                UpdateBillRate(row);
                CalcTotal(row);
                needSave = true;
            }

            if (e.Column == colManual)
            {
                bool manual = (bool)row[colManual.FieldName];
                if (!manual)
                {
                    foreach (var timeCode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
                    {
                        row[EnterHoursI(timeCode)] = 0;
                    }
                    CalcTotal(row);
                }
                needSave = true;
            }

            if (e.Column == colLevel1Code)
            {
                row[colLevel2Code.FieldName] = DBNull.Value;
                row[colLevel3Code.FieldName] = DBNull.Value;
                row[colLevel4Code.FieldName] = DBNull.Value;
                needSave = true;
            }

            if (e.Column == colLevel2Code)
            {
                row[colLevel3Code.FieldName] = DBNull.Value;
                row[colLevel4Code.FieldName] = DBNull.Value;
                needSave = true;
            }

            if (e.Column == colLevel3Code)
            {
                row[colLevel4Code.FieldName] = DBNull.Value;
                needSave = true;
            }

            if (e.Column.FieldName.Contains(strEnterHours))
            {
                CalcOvertime(row, e.Column.FieldName);
                CalcTotal(row);
                needSave = true;
            }

            if (new GridColumn[] { colChangeOrder, colBillable }.Contains(e.Column))
            {
                needSave = true;
            }

            if (needSave && !gvLabour.IsNewItemRow(e.RowHandle))
            {
                LabourTimeEntry.SqlUpdate((int)row[colId.FieldName], (int)row[colEmpNum.FieldName], ConvertEx.ToNullable<int>(row[colChangeOrder.FieldName]),
                    ConvertEx.ToNullable<int>(row[colLevel1Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel2Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel3Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel4Code.FieldName]),
                    (bool)row[colBillable.FieldName], (bool)row[colManual.FieldName], (string)row[colWorkClass.FieldName], ConvertEx.ToNullable<decimal>(row[colIncludedHours.FieldName]), ConvertEx.ToNullable<decimal>(row[colTotalHours.FieldName]), ConvertEx.ToNullable<decimal>(row[colBillAmount.FieldName]));
                row.AcceptChanges();

                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
        }

        private void UpdateBillRate(DataRow row)
        {
            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
            {
                decimal? billRate = ProjectWorkClass.GetBillRate(_headerRecord.ProjectId, timecode.MatchId, (string)row[colWorkClass.FieldName]);
                row[BillRateI(timecode)] = (object)billRate ?? DBNull.Value;
                if (row[colId.FieldName] != DBNull.Value)
                {
                    LabourTimeDetail.SqlUpdateBillRate((int)row[colId.FieldName], timecode.MatchId, billRate);
                }
            }
        }

        private void CalcOvertime(DataRow row, string colName)
        {
            var sqlUpdate = new Action<int, decimal>((timeCodeId, val) =>
            {
                if (row[colId.FieldName] != DBNull.Value)
                {
                    if (TimeCode.GetTimeCode(timeCodeId).ValueType == EnumValueType.Hours)
                        LabourTimeDetail.SqlUpdateHours((int)row[colId.FieldName], timeCodeId, val);
                    else
                        LabourTimeDetail.SqlUpdateAmount((int)row[colId.FieldName], timeCodeId, val);
                }
            });

            bool handled = false;
            if ((bool)row[colManual.FieldName] == false)
            {
                var ot = OvertimeLimit.GetOvertime(_headerRecord.ProjectId, (int)row[colEmpNum.FieldName]);

                var regTimeCode = TimeCode.GetTimeCodeList(EnumBillingRateType.Regular).SingleOrDefault(x => colName == EnterHoursI(x));
                if (regTimeCode != null && regTimeCode.OvertimeId != null && ot != null)
                {
                    int? currId = ConvertEx.ToNullable<int>(row[colId.FieldName]);
                    decimal dayHours = LabourTimeEntry.GetDayHours(_headerRecord.ProjectId, (int)row[colEmpNum.FieldName], _headerRecord.LogDate, currId);
                    decimal weekHours = LabourTimeEntry.GetWeekHours(_headerRecord.ProjectId, (int)row[colEmpNum.FieldName], _headerRecord.LogDate, currId);

                    dayHours += ConvertEx.ToNullable<decimal>(row[colName]) ?? 0;
                    weekHours += ConvertEx.ToNullable<decimal>(row[colName]) ?? 0;

                    decimal overHours = ot.Calc(dayHours, weekHours);

                    row[EnterHoursI(regTimeCode.OvertimeId.Value)] = overHours;
                    sqlUpdate(regTimeCode.OvertimeId.Value, overHours);
                    dayHours -= overHours;

                    row[colName] = dayHours;
                    sqlUpdate(regTimeCode.MatchId, dayHours);
                    handled = true;
                }
            }

            if (!handled)
            {
                sqlUpdate(int.Parse(colName.Replace(strEnterHours, "")), ConvertEx.ToNullable<decimal>(row[colName]) ?? 0);
            }
        }

        private void CalcTotal(DataRow row)
        {
            decimal includedHours = 0;
            decimal totalHours = 0;
            decimal billAmount = 0;

            foreach (var timeCode in TimeCode.SubList(TimeCode.EnumValueType.Hours))
            {
                if (row[EnterHoursI(timeCode)] != DBNull.Value)
                {
                    if (timeCode.IncludedInWeekCalc)
                    {
                        includedHours += Convert.ToDecimal(row[EnterHoursI(timeCode)]);
                    }
                    totalHours += Convert.ToDecimal(row[EnterHoursI(timeCode)]);

                    if (row[BillRateI(timeCode)] != DBNull.Value)
                    {
                        billAmount += Convert.ToDecimal(row[BillRateI(timeCode)]) * Convert.ToDecimal(row[EnterHoursI(timeCode)]);
                    }
                }
            }

            foreach (var timeCode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
            {
                if (row[EnterAmountI(timeCode)] != DBNull.Value)
                {
                    billAmount += Convert.ToDecimal(row[EnterAmountI(timeCode)]);
                }
            }

            row[colIncludedHours.FieldName] = includedHours;
            row[colTotalHours.FieldName] = totalHours;
            row[colBillAmount.FieldName] = billAmount;
        }

        private void gvEmployee_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRow row = gvLabour.GetDataRow(e.RowHandle);

            var EnsureMandatoryColumn = new Func<GridColumn, string, bool>((col, msg) =>
            {
                if (row[col.FieldName] == DBNull.Value)
                {
                    e.Valid = false;
                    e.ErrorText = msg;
                    return true;
                }
                return false;
            });

            if (EnsureMandatoryColumn(colEmpNum, "Must select an Employee.")) return;
            if (EnsureMandatoryColumn(colWorkClass, "Must select a WorkClass.")) return;
            if (colLevel1Code.Visible && EnsureMandatoryColumn(colLevel1Code, $"Need to select a {colLevel1Code.Caption}.")) return;
            if (colLevel2Code.Visible && EnsureMandatoryColumn(colLevel2Code, $"Need to select a {colLevel2Code.Caption}.")) return;
            if (colLevel3Code.Visible && EnsureMandatoryColumn(colLevel3Code, $"Need to select a {colLevel3Code.Caption}.")) return;
            if (colLevel4Code.Visible && EnsureMandatoryColumn(colLevel4Code, $"Need to select a {colLevel4Code.Caption}.")) return;
        }

        private void gvEmployee_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            DataRow row = gvLabour.GetDataRow(e.RowHandle);
            if (e.Column == colLevel1Code)
            {
                var codeList = LevelOneCode.ListForProject(_headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
            else if (e.Column == colLevel2Code)
            {
                int level1Id = row[colLevel1Code.FieldName] == DBNull.Value ? -1 : (int)row[colLevel1Code.FieldName];
                var codeList = LevelTwoCode.SubList(level1Id, _headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
            else if (e.Column == colLevel3Code)
            {
                int level2Id = row[colLevel2Code.FieldName] == DBNull.Value ? -1 : (int)row[colLevel2Code.FieldName];
                var codeList = LevelThreeCode.SubList(level2Id, _headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
            else if (e.Column == colLevel4Code)
            {
                int level3Id = row[colLevel3Code.FieldName] == DBNull.Value ? -1 : (int)row[colLevel3Code.FieldName];
                var codeList = LevelFourCode.SubList(level3Id, _headerRecord.ProjectId).Select(code => new { MatchId = code.MatchId, Code = code.Code, Desc = code.Desc, DisplayName = code.DisplayName }).Distinct().ToList();
                luColLevel.DataSource = codeList.OrderBy(x => x.MatchId);
                e.RepositoryItem = luColLevel;
            }
        }

        void SetEnabled(bool enabled)
        {
            gvLabour.OptionsBehavior.Editable = enabled;
            gvLabour.OptionsSelection.EnableAppearanceFocusedCell = enabled;
        }

        public void LoadFromPrevDay()
        {
            if (LabourTimeEntry.CopyDataFromPrevDay(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetCurrent(_headerRecord);
                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
            else
            {
                GuiCommon.ShowMessage("The previous day data is not available.");
            }
        }

        public void LoadFromTemplate()
        {
            if (LabourTimeEntry.CopyDataFromTemplate(_headerRecord.ProjectId, _headerRecord.LogDate, _headerRecord.Id))
            {
                SetCurrent(_headerRecord);
                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
            else
            {
                GuiCommon.ShowMessage("The template data is not available.");
            }
        }

        private void gvLabour_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (GuiCommon.ShowMessage("Delete Record?", "Confirmation", PopupType.Yes_No) == PopupResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DataRow row = gvLabour.GetDataRow(e.RowHandle);
                LabourTimeEntry.DeleteEntry((int)row[colId.FieldName]);
                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
        }

        private void gvLabour_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (gvLabour.IsNewItemRow(e.RowHandle))
            {
                DataRowView row = e.Row as DataRowView;
                row[colId.FieldName] = LabourTimeEntry.SqlInsert(_headerRecord.Id, (int)row[colEmpNum.FieldName], ConvertEx.ToNullable<int>(row[colChangeOrder.FieldName]),
                    ConvertEx.ToNullable<int>(row[colLevel1Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel2Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel3Code.FieldName]), ConvertEx.ToNullable<int>(row[colLevel4Code.FieldName]),
                    (bool)row[colBillable.FieldName], (bool)row[colManual.FieldName], (string)row[colWorkClass.FieldName], ConvertEx.ToNullable<decimal>(row[colIncludedHours.FieldName]),
                    ConvertEx.ToNullable<decimal>(row[colTotalHours.FieldName]), ConvertEx.ToNullable<decimal>(row[colBillAmount.FieldName]));

                foreach (var timeCode in TimeCode.SubList(EnumValueType.Hours))
                {
                    LabourTimeDetail.SqlInsert((int)row[colId.FieldName], timeCode.MatchId, ConvertEx.ToNullable<decimal>(row[BillRateI(timeCode)]), ConvertEx.ToNullable<decimal>(row[EnterHoursI(timeCode)]), null);
                }

                foreach (var timeCode in TimeCode.SubList(EnumValueType.Dollars))
                {
                    LabourTimeDetail.SqlInsert((int)row[colId.FieldName], timeCode.MatchId, null, null, ConvertEx.ToNullable<decimal>(row[EnterAmountI(timeCode)]));
                }

                LemHeader.SqlUpdateSubmitStatus(_headerRecord.Id, EnumSubmitStatus.Open);
            }
        }

        private void LookupEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                (sender as LookUpEdit).EditValue = null;
            }
        }

        private void gvLabour_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column.FieldName.Contains(strEnterHours))
            {
                if (e.Value!=null && Convert.ToInt32(e.Value)<0)
                {
                    e.ErrorText = "Invalid Work Hours.";
                    e.Valid = false;
                    return;
                }
            }

            if (column.FieldName.Contains(strEnterAmount))
            {
                if (e.Value != null && Convert.ToInt32(e.Value) < 0)
                {
                    e.ErrorText = "Invalid Amount.";
                    e.Valid = false;
                    return;
                }
            }
        }
    }
}
