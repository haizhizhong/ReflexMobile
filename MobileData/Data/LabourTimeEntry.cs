using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public enum EnumLemType
    {
        Labour = 'L',
        Equipment = 'E',
        Material = 'M',
        Subcontract = 'S',
        Other = 'O'
    }

    public class LabourTimeEntry       // WS_EMP_TimeClock
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public int HeaderId;
        public int EmpNum;
        public int? ChangeOrderId;
        public bool Billable;
        public string WorkClassCode;

        public int? Level1Id;
        public int? Level2Id;
        public int? Level3Id;
        public int? Level4Id;
        public bool Manual;      // Vs Auto calc overtime

        public decimal? IncludedHours;
        public decimal? TotalHours;
        public decimal? BillAmount;
        
        public List<LabourTimeDetail> DetailList = new List<LabourTimeDetail>();

        public LabourTimeEntry()
        {
        }

        public LabourTimeEntry(DataRow row)
        {
            Id = (int)row["Id"];
            MatchId = (int)row["MatchId"];
            CompanyId = (int)row["CompanyId"];
            HeaderId = (int)row["LogHeaderId"];
            EmpNum = (int)row["EmpNum"];
            ChangeOrderId = ConvertEx.ToNullable<int>(row["ChangeOrderId"]);
            Level1Id = ConvertEx.ToNullable<int>(row["Level1Id"]);
            Level2Id = ConvertEx.ToNullable<int>(row["Level2Id"]);
            Level3Id = ConvertEx.ToNullable<int>(row["Level3Id"]);
            Level4Id = ConvertEx.ToNullable<int>(row["Level4Id"]);
            Billable = (bool)row["Billable"];
            WorkClassCode = (string)row["WorkClassCode"];
            Manual = (bool)row["Manual"];
            IncludedHours = ConvertEx.ToNullable<decimal>(row["IncludedHours"]);
            TotalHours = ConvertEx.ToNullable<decimal>(row["TotalHours"]);
            BillAmount = ConvertEx.ToNullable<decimal>(row["BillAmount"]);
        }

        public static LabourTimeEntry GetLabourEntry(int id)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from LabourTimeEntry where id={id} and companyId={Company.CurrentId}");
            LabourTimeEntry entry = table.Select().Select( r=> new LabourTimeEntry(r)).Single();
            entry.GetDetailList();
            return entry;
        }

        public void GetDetailList()
        {
            DetailList.Clear();

            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from LabourTimeDetail where EntryId = {Id}");
            table.Select().ToList().ForEach(r => DetailList.Add(new LabourTimeDetail(r)));
        }

        public static List<LabourTimeEntry> GetLabourEntryList(int logHeaderId)
        {
            string sql = $"select * from LabourTimeEntry where CompanyId={Company.CurrentId} and LogHeaderId={logHeaderId} and deleted=0";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<LabourTimeEntry> list = table.Select().Select(r => new LabourTimeEntry(r)).ToList();
            list.ForEach(x => x.GetDetailList());

            return list;
        }

        public static decimal GetDayHours(int projectId, int empNum, DateTime currDate, int? currId)
        {
            var regCodeIds = TimeCode.ListForCompany().Where(x => x.BillingType == TimeCode.EnumBillingRateType.Regular).Select( x=> x.MatchId).ToList();
            string txtRegCodeIds = StrEx.GetIdListText(regCodeIds);

            string sql = $"select isnull(sum(d.WorkHours), 0.0) from LemHeader h " +
                $"join LabourTimeEntry e on h.Id = e.LogHeaderId " +
                $"join LabourTimeDetail d on e.Id = d.EntryId " +
                $"where h.projectId={projectId} and h.LogDate='{currDate}' and h.deleted=0 and e.EmpNum = {empNum} and e.deleted=0 " +
                $"and d.TimeCodeId in ({txtRegCodeIds}) and e.id<>{currId ?? -1}";

            return (decimal)MobileCommon.ExecuteScalar(sql);
        }

        public static decimal GetWeekHours(int projectId, int empNum, DateTime currDate, int? currId)
        {
            int days = (currDate.DayOfWeek - Company.GetCurrCompany().WeekStart) % 7;
            DateTime firstDay = currDate.AddDays(-days);

            string sql = $"select isnull(sum(e.IncludedHours), 0.0) from LemHeader h join LabourTimeEntry e on h.Id = e.LogHeaderId " +
                $"where h.projectId={projectId} and h.LogDate >= '{firstDay}' and h.LogDate <= '{currDate}' and h.deleted=0 " +
                $"and e.EmpNum={empNum} and e.deleted = 0 and e.id<>{currId ?? -1}";

            return (decimal)MobileCommon.ExecuteScalar(sql);
        }

        public static bool CopyDataFromPrevDay(int projectId, DateTime currDate, int currHeaderId)
        {
            string sql = $"select top 1 id from LemHeader " +
                $"where LogDate<'{currDate.Date}' and ProjectID = {projectId} and CompanyId = {Company.CurrentId} and deleted = 0 " +
                $"order by LogDate desc";

            object srcHeaderId = MobileCommon.ExecuteScalar(sql);
            if (srcHeaderId != null)
            {
                var srcList = GetLabourEntryList((int)srcHeaderId);
                foreach (var src in srcList)
                {
                    int entryId = SqlInsert(currHeaderId, src.EmpNum, src.ChangeOrderId, src.Level1Id, src.Level2Id, src.Level3Id, src.Level4Id, src.Billable, src.Manual, src.WorkClassCode, src.IncludedHours, src.TotalHours, src.BillAmount);
                    src.DetailList.ForEach( d => LabourTimeDetail.SqlInsert(entryId, d.TimeCodeId, d.BillRate, d.WorkHours, d.Amount));
                }
                return srcList.Any();
            }

            return false;
        }

        public static bool CopyDataFromTemplate(int projectId, DateTime currDate, int currHeaderId)
        {
            var filtered = LabourTemplate.GetTemplate(projectId, currDate);
            if (filtered.Count > 0)
            {
                Project project = Project.GetProject(projectId);

                foreach (var src in filtered)
                {
                    int entryId = SqlInsert(currHeaderId, src.EmpNum, null, null, null, null, null, project.Billable, false, src.WorkClassCode, null, null, null);

                    foreach (var tc in TimeCode.SubList(TimeCode.EnumValueType.Hours))
                    {
                        decimal? billRate = ProjectWorkClass.GetBillRate(projectId, tc.MatchId, src.WorkClassCode);
                        LabourTimeDetail.SqlInsert(entryId, tc.MatchId, billRate, null, null);
                    }

                    foreach (var tc in TimeCode.SubList(TimeCode.EnumValueType.Dollars))
                    {
                        LabourTimeDetail.SqlInsert(entryId, tc.MatchId, null, null, null);
                    }
                }
                return true;
            }

            return false;
        }

        public static int SqlInsert(int headerId, int empNum, int? changeOrderId, int? level1Id, int? level2Id, int? level3Id, int? level4Id, bool billable, bool manual, string workClassCode, decimal? includedHours, decimal? totalHours, decimal? billAmount)
        {
            string sql = $"insert LabourTimeEntry(MatchId, CompanyId, LogHeaderId, EmpNum, ChangeOrderId, Level1Id, Level2Id, Level3Id, Level4Id, Billable, Manual, WorkClassCode, IncludedHours, TotalHours, BillAmount, SyncStatus, Deleted) " +
                $"values(-1, {Company.CurrentId}, {headerId}, {empNum}, {StrEx.ValueOrNull(changeOrderId)}, {StrEx.ValueOrNull(level1Id)}, {StrEx.ValueOrNull(level2Id)}, " +
                $"{StrEx.ValueOrNull(level3Id)}, {StrEx.ValueOrNull(level4Id)}, '{billable}', '{manual}', '{workClassCode}', {StrEx.ValueOrNull(includedHours)}, {StrEx.ValueOrNull(totalHours)}, {StrEx.ValueOrNull(billAmount)}, '{EnumRecordSyncStatus.NoSubmit}', 0); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
        }

        public static void SqlUpdate(int id, int empNum, int? changeOrderId, int? level1Id, int? level2Id, int? level3Id, int? level4Id, bool billable, bool manual, string workClassCode, decimal? includedHours, decimal? totalHours, decimal? billAmount)
        {
            string sql = $"update LabourTimeEntry set EmpNum={empNum}, ChangeOrderId={StrEx.ValueOrNull(changeOrderId)}, Level1Id={StrEx.ValueOrNull(level1Id)}, Level2Id={StrEx.ValueOrNull(level2Id)}, " +
                $"Level3Id={StrEx.ValueOrNull(level3Id)}, Level4Id={StrEx.ValueOrNull(level4Id)}, Billable='{billable}', Manual='{manual}', WorkClassCode='{workClassCode}', " +
                $"IncludedHours={StrEx.ValueOrNull(includedHours)}, TotalHours={StrEx.ValueOrNull(totalHours)}, BillAmount={StrEx.ValueOrNull(billAmount)}, SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where Id={id} ";

            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void DeleteEntry(int id)
        {
            LabourTimeEntry curr = LabourTimeEntry.GetLabourEntry(id);
            if (curr.MatchId != -1)
            {
                MobileCommon.ExecuteNonQuery($"update LabourTimeEntry set deleted=1 where id={id}");
                DeleteHistory.SqlInsert(DeleteHistory.LabourTimeEntry, curr.MatchId);
            }
            else
            {
                SqlForceDelete(id);
            }
        }

        public static void SqlForceDelete(int id)
        {
            MobileCommon.ExecuteNonQuery($"delete LabourTimeDetail where EntryId={id}");
            MobileCommon.ExecuteNonQuery($"delete LabourTimeEntry where id={id}");
        }
    }
}
