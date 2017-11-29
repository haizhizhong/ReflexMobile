using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.TimeCode;

namespace MobileLEM
{
    public partial class ucToolEmpSum : DevExpress.XtraEditors.XtraUserControl
    {
        class ColName
        {
            public const string EmpNum = "EmpNum";
            public const string EmployeeName = "EmployeeName";
            public const string WorkClass = "WorkClass";
            public const string Project = "Project";
            public const string TotalHours = "TotalHours";
            public const string BillAmount = "BillAmount";

            public const string BillRate = "BillRate";
            public const string EnterValue = "EnterValue";

            public static string BillRateI(TimeCode code)
            {
                return $"{BillRate}{code.MatchId}";
            }

            public static string EnterValueI(TimeCode code)
            {
                return $"{EnterValue}{code.MatchId}";
            }
        };

        public ucToolEmpSum()
        {
            InitializeComponent();

            luProject.Properties.DataSource = Project.AccessibleList().Select(p => new { Project = p.Name, Code = p.Code, MatchId = p.MatchId, DisplayName = p.DisplayName });
            luLemNumber.Properties.DataSource = LemHeader.GetAllLemNumber().Select(x => new { LemNum = x });

            Func<string, string, int, GridColumn> CreateColumn = new Func<string, string, int, GridColumn>((field, caption, visibleIndex) =>
            {
                GridColumn column = gvSummary.Columns.AddVisible(field, caption);
                column.VisibleIndex = visibleIndex;
                return column;
            });

            int visionIndex = 0;
            new List<string> { ColName.EmpNum, ColName.EmployeeName, ColName.WorkClass, ColName.Project }.ForEach(
                x => gvSummary.Columns[x].VisibleIndex = visionIndex++
           );

            foreach (var timecode in TimeCode.SubList(EnumValueType.Hours))
            {
                tableLabour.Columns.Add(ColName.BillRateI(timecode), Type.GetType("System.Decimal"));
                var rateCol = CreateColumn(ColName.BillRateI(timecode), $"{timecode.Desc} Bill Rate", visionIndex++);
                rateCol.DisplayFormat.FormatType = FormatType.Numeric;
                rateCol.DisplayFormat.FormatString = "c2";
                rateCol.OptionsColumn.AllowEdit = false;

                tableLabour.Columns.Add(ColName.EnterValueI(timecode), Type.GetType("System.Decimal"));
                var hourCol = CreateColumn(ColName.EnterValueI(timecode), $"{timecode.Desc} Hours", visionIndex++);
                hourCol.DisplayFormat.FormatType = FormatType.Numeric;
                hourCol.DisplayFormat.FormatString = "n2";
                hourCol.OptionsColumn.AllowEdit = false;
                hourCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, hourCol.FieldName, "{0:n2}")});
            }

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
            {
                tableLabour.Columns.Add(ColName.EnterValueI(timecode), Type.GetType("System.Decimal"));
                var amountCol = CreateColumn(ColName.EnterValueI(timecode), timecode.Desc, visionIndex++);
                amountCol.DisplayFormat.FormatType = FormatType.Numeric;
                amountCol.DisplayFormat.FormatString = "c2";
                amountCol.OptionsColumn.AllowEdit = false;
                amountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, amountCol.FieldName, "{0:c2}")});
            }

            gvSummary.Columns[ColName.TotalHours].VisibleIndex = visionIndex++;
            gvSummary.Columns[ColName.BillAmount].VisibleIndex = visionIndex++;
            gvSummary.BestFitColumns(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? project = (int?)luProject.EditValue;
            DateTime? from = (DateTime?)deFromDate.EditValue;
            DateTime? to = (DateTime?)deToDate.EditValue;
            string lumNum = (string)luLemNumber.EditValue;

            var logList = LemHeader.GetLogHeaderList(project, from, to, null, lumNum);
            SetData(logList);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        public void ClearAll()
        {
            luProject.EditValue = null;
            deFromDate.EditValue = null;
            deToDate.EditValue = null;
            luLemNumber.EditValue = null;

            SetData(new List<LemHeader>());
        }

        public void SetData(List<LemHeader>headerList)
        {
            tableLabour.Clear();

            var table = LemHeader.GetEmployeeSummary(headerList.Select(x => x.Id).ToList());
            var list = table.Select().Select(r => new
            {
                EmpNum = Convert.ToInt32(r["EmpNum"]),
                WorkClassCode = Convert.ToString(r["WorkClassCode"]),
                ProjectId = Convert.ToInt32(r["ProjectId"]),
                TimeCodeId = Convert.ToInt32(r["TimeCodeId"]),
                SumWorkHour = ConvertEx.ToNullable<decimal>(r["SumWorkHour"]),
                SumAmount = ConvertEx.ToNullable<decimal>(r["SumAmount"]),
            });

            var groupList = list.ToLookup(x => new
            {
                x.EmpNum,
                x.WorkClassCode,
                x.ProjectId,
                Project = Project.GetProject(x.ProjectId).DisplayName,
                EmpName = Employee.GetEmployee(x.EmpNum)?.DisplayName,
                WorkClass = WorkClass.GetWorkClass(x.WorkClassCode).DisplayName
            }).OrderBy(x => x.Key.EmpName).ThenBy(x => x.Key.WorkClass).ThenBy(x => x.Key.Project).ToList();

            groupList.ForEach(g =>
            {
                var row = tableLabour.Rows.Add(
                 g.Key.EmpNum,
                 g.Key.EmpName,
                 g.Key.WorkClass,
                 g.Key.Project,
                 null,
                 null);

                decimal? billRate;
                decimal totalHours = 0;
                decimal billAmounts = 0;
                foreach (var timecode in TimeCode.ListForCompany())
                {
                    if (timecode.ValueType == EnumValueType.Hours)
                    {
                        billRate = ProjectWorkClass.GetBillRate(g.Key.ProjectId, timecode.MatchId, g.Key.WorkClassCode);
                        row[ColName.BillRateI(timecode)] = (object)billRate ?? DBNull.Value;

                        decimal hours = g.Where(x => x.TimeCodeId == timecode.MatchId).Sum(x => x.SumWorkHour) ?? 0;
                        row[ColName.EnterValueI(timecode)] = hours != 0 ? (object)hours : DBNull.Value;

                        totalHours += hours;
                        billAmounts += (billRate ?? 0) * hours;
                    }
                    else
                    {
                        decimal amount = g.Where(x => x.TimeCodeId == timecode.MatchId).Sum(x => x.SumAmount) ?? 0;
                        row[ColName.EnterValueI(timecode)] = amount != 0 ? (object)amount : DBNull.Value;
                        billAmounts += amount;
                    }

                    row[ColName.TotalHours] = totalHours != 0 ? (object)totalHours : DBNull.Value;
                    row[ColName.BillAmount] = billAmounts != 0 ? (object)billAmounts : DBNull.Value;
                }
            });
        }

        private void luProject_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            luProject.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : luProject.EditValue;
        }

        private void deFromDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            deFromDate.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : deFromDate.EditValue;
        }

        private void deToDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            deToDate.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : deToDate.EditValue;
        }

        private void luLemNumber_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            luLemNumber.EditValue = e.Button.Kind == ButtonPredefines.Delete ? null : luLemNumber.EditValue;
        }
    }
}
