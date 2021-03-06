﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using MobileData;
using DevExpress.Utils;
using static MobileData.TimeCode;
using ReflexCommon;

namespace MobileLEM
{
    public partial class ucEmployeeSummary : DevExpress.XtraEditors.XtraUserControl
    {
        LemHeader _headerRecord;
        public static string BillRateI(TimeCode code) => $"BillRate{code.MatchId}";
        public static string EnterValueI(TimeCode code) => $"EnterValue{code.MatchId}";

        public ucEmployeeSummary()
        {
            InitializeComponent();

            Func<string, string, int, GridColumn> CreateColumn = new Func<string, string, int, GridColumn>((field, caption, visibleIndex) =>
            {
                GridColumn column = gvSummary.Columns.AddVisible(field, caption);
                column.VisibleIndex = visibleIndex;
                return column;
            });

            int visionIndex = 0;
            new List<GridColumn> { colEmpNum, colEmployeeName, colWorkClass }.ForEach(
                x => x.VisibleIndex = visionIndex++
           );

            foreach (var timecode in TimeCode.SubList(EnumValueType.Hours))
            {
                tableLabour.Columns.Add(BillRateI(timecode), Type.GetType("System.Decimal"));
                var rateCol = CreateColumn(BillRateI(timecode), $"{timecode.Desc} Bill Rate", visionIndex++);
                rateCol.DisplayFormat.FormatType = FormatType.Numeric;
                rateCol.DisplayFormat.FormatString = "c2";
                rateCol.OptionsColumn.AllowEdit = false;

                tableLabour.Columns.Add(EnterValueI(timecode), Type.GetType("System.Decimal"));
                var hourCol = CreateColumn(EnterValueI(timecode), $"{timecode.Desc} Hours", visionIndex++);
                hourCol.DisplayFormat.FormatType = FormatType.Numeric;
                hourCol.DisplayFormat.FormatString = "n2";
                hourCol.OptionsColumn.AllowEdit = false;
                hourCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, hourCol.FieldName, "{0:n2}")});
            }

            foreach (var timecode in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
            {
                tableLabour.Columns.Add(EnterValueI(timecode), Type.GetType("System.Decimal"));
                var amountCol = CreateColumn(EnterValueI(timecode), timecode.Desc, visionIndex++);
                amountCol.DisplayFormat.FormatType = FormatType.Numeric;
                amountCol.DisplayFormat.FormatString = "c2";
                amountCol.OptionsColumn.AllowEdit = false;
                amountCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, amountCol.FieldName, "{0:c2}")});
            }

            colTotalHours.VisibleIndex = visionIndex++;
            colBillAmount.VisibleIndex = visionIndex++;
            gvSummary.BestFitColumns(true);
        }

        public void SetCurrent(LemHeader header)
        {
            _headerRecord = header;

            tableLabour.Clear();

            var table = LemHeader.GetEmployeeSummary(new List<int> { header.Id });
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
                EmpName = Employee.GetEmployee(x.EmpNum)?.DisplayName,
                WorkClass = WorkClass.GetWorkClass(x.WorkClassCode).DisplayName
            }).OrderBy(x => x.Key.EmpName).ThenBy(x => x.Key.WorkClass).ToList();

            groupList.ForEach(g =>
            {
                var row = tableLabour.Rows.Add(
                 g.Key.EmpNum,
                 g.Key.EmpName,
                 g.Key.WorkClass,
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
                        row[BillRateI(timecode)] = (object)billRate ?? DBNull.Value;

                        decimal hours = g.Where(x => x.TimeCodeId == timecode.MatchId).Sum(x => x.SumWorkHour) ?? 0;
                        row[EnterValueI(timecode)] = hours != 0 ? (object)hours : DBNull.Value;

                        totalHours += hours;
                        billAmounts += (billRate ?? 0) * hours;
                    }
                    else
                    {
                        decimal amount = g.Where(x => x.TimeCodeId == timecode.MatchId).Sum(x => x.SumAmount) ?? 0;
                        row[EnterValueI(timecode)] = amount != 0 ? (object)amount : DBNull.Value;
                        billAmounts += amount;
                    }

                    row[colTotalHours.FieldName] = totalHours != 0 ? (object)totalHours : DBNull.Value;
                    row[colBillAmount.FieldName] = billAmounts != 0 ? (object)billAmounts : DBNull.Value;
                }
            });
        }
    }
}
