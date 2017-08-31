using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    //public enum LemStatus
    //{
    //    Released = 'R',
    //    Unreleased = 'U',
    //    Historical = 'H',
    //    Pending = 'P',
    //    Denied = 'D',
    //    Approved = 'A',
    //    All = '%'
    //}

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
        public int LogHeaderId;
        public int EmpNum;
        public int Level1Id;
        public int Level2Id;
        public bool Billable;       //?
        public int WorkClassId;
        public string Comments;
        // LOA, Equip, BillRate, Other

        public decimal TotalHours;
        public decimal BillAmount;
        public DateTime TimeStamp;

        public List<LabourTimeDetail> DetailList = new List<LabourTimeDetail>();

        public static LabourTimeEntry GetLabourEntry(int id)
        {
            DataTable table = Common.ExecuteDataAdapter($"select * from LabourTimeEntry where id={id} and companyId={Company.CurrentId}");
            LabourTimeEntry entry = new LabourTimeEntry
            {
                Id = (int)table.Rows[0]["Id"],
                MatchId = (int)table.Rows[0]["MatchId"],
                CompanyId = (int)table.Rows[0]["CompanyId"],
                LogHeaderId = (int)table.Rows[0]["LogHeaderId"],
                EmpNum = (int)table.Rows[0]["EmpNum"],
                Level1Id = table.Rows[0]["Level1Id"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["Level1Id"]),
                Level2Id = table.Rows[0]["Level2Id"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["Level2Id"]),
                Billable = (bool)table.Rows[0]["Billable"],
                WorkClassId = (int)table.Rows[0]["WorkClassId"],
                Comments = $"{table.Rows[0]["Comments"]}",
                TotalHours = table.Rows[0]["TotalHours"] == DBNull.Value ? 0 : Convert.ToDecimal(table.Rows[0]["TotalHours"]),
                BillAmount = table.Rows[0]["BillAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(table.Rows[0]["BillAmount"]),
                TimeStamp = (DateTime)table.Rows[0]["TimeStamp"]
            };

            entry.GetDetailList();
            return entry;
        }

        public void GetDetailList()
        {
            DetailList.Clear();

            DataTable table = Common.ExecuteDataAdapter($"select * from LabourTimeDetail where EntryId = {Id}");
            table.Select().ToList().ForEach(r => DetailList.Add(
                new LabourTimeDetail
                {
                    Id = (int)r["Id"],
                    MatchId = (int)r["MatchId"],
                    CompanyId = (int)r["CompanyId"],
                    EntryId = Id,
                    TimeCodeId = (int)r["TimeCodeId"],
                    EnterValue = (decimal)r["WorkHours"],
                    TimeStamp = (DateTime)r["TimeStamp"]
                }));
        }

        public static List<LabourTimeEntry> GetLabourEntryList(int logHeaderId)
        {
            List<LabourTimeEntry> list = new List<LabourTimeEntry>();

            string sql = $"select m.id as MId, m.MatchID as MMId, m.CompanyId as CId, m.*, s.id as SId, s.MatchId as SMId, s.* from LabourTimeEntry m " +
                $"LEFT OUTER JOIN  LabourTimeDetail s on m.Id=s.EntryId " +
                $"where m.CompanyId={Company.CurrentId} and m.LogHeaderId={logHeaderId}";
            DataTable table = Common.ExecuteDataAdapter(sql);
            table.Select().ToList().ForEach(r =>
            {
                LabourTimeEntry lte = list.SingleOrDefault(x => x.Id == (int)r["MId"]);
                if (lte == null)
                {
                    lte = new LabourTimeEntry
                    {
                        Id = (int)r["MId"],
                        MatchId = (int)r["MMId"],
                        CompanyId = (int)r["CId"],
                        LogHeaderId = (int)r["LogHeaderId"],
                        EmpNum = (int)r["EmpNum"],
                        Level1Id = r["Level1Id"] == DBNull.Value ? 0 : Convert.ToInt32(r["Level1Id"]),
                        Level2Id = r["Level2Id"] == DBNull.Value ? 0 : Convert.ToInt32(r["Level2Id"]),
                        Billable = (bool)r["Billable"],
                        WorkClassId = (int)r["WorkClassId"],
                        Comments = $"{r["Comments"]}",
                        TotalHours = r["TotalHours"] == DBNull.Value ? 0 : (decimal)r["TotalHours"],
                        BillAmount = r["BillAmount"] == DBNull.Value ? 0 : (decimal)r["BillAmount"],
                        TimeStamp = (DateTime)r["TimeStamp"]
                    };
                    list.Add(lte);
                }

                if (r["SId"] != DBNull.Value)
                {
                    LabourTimeDetail detail = new LabourTimeDetail
                    {
                        Id = (int)r["SId"],
                        MatchId = (int)r["SMId"],
                        CompanyId = (int)r["CId"],
                        EntryId = lte.Id,
                        TimeCodeId = (int)r["TimeCodeId"],
                        EnterValue = (decimal)r["WorkHours"],
                        TimeStamp = (DateTime)r["TimeStamp"]
                    };
                    lte.DetailList.Add(detail);
                }
            });

            return list;
        }

        public static bool CopyDataFromPrevDay(int projectId, DateTime currDate, int currHeaderId)
        {
            string sql = $"select top 1 h.id from LemLogHeader h " +
                $"join LabourTimeEntry e on h.Id = e.LogHeaderId " +
                $"where h.LogDate < '{currDate}' and ProjectID = {projectId} " +
                $"group by h.id, h.LogDate " +
                $"having count(e.Id) > 0 " +
                $"order by h.LogDate desc";

            object srcHeaderId = Common.ExecuteScalar(sql);
            if (srcHeaderId != null)
            {
                var srcList = GetLabourEntryList((int)srcHeaderId);
                foreach (var src in srcList)
                {
                    sql = $"insert LabourTimeEntry(MatchID, CompanyId, LogHeaderId, EmpNum, Level1Id, Level2Id, Billable, WorkClassId, Comments, TotalHours, BillAmount, TimeStamp) " +
                        $"values (-1, {src.CompanyId}, {currHeaderId}, {src.EmpNum}, {src.Level1Id}, {src.Level2Id}, '{src.Billable}', {src.WorkClassId}, 'Loaded from previous day', {src.TotalHours}, {src.BillAmount}, getdate()); " +
                        $"Select CAST(SCOPE_IDENTITY() AS INT);";
                    int entryId = Convert.ToInt32(Common.ExecuteScalar(sql));

                    foreach (var detail in src.DetailList)
                    {
                        sql = $"insert LabourTimeDetail(MatchID, CompanyID, EntryID, TimeCodeId, WorkHours, TimeStamp) " +
                            $"values(-1, {detail.CompanyId}, {entryId}, {detail.TimeCodeId}, {detail.EnterValue}, getdate())";
                        Common.ExecuteNonQuery(sql);
                    }
                }
                return true;
            }

            return false;
        }

        public static bool CopyDataFromTemplate(int projectId, DateTime currDate, int currHeaderId)
        {
            var filtered = LabourTemplate.GetTemplate(projectId, currDate);
            if (filtered.Count > 0)
            {
                Project project = Project.GetProject(projectId);

                foreach (var temp in filtered)
                {
                    var pwc = ProjectWorkClass.GetProjectWorkClass(temp.ProjectWorkClassId);
                    var wc = WorkClass.GetWorkClass(pwc.WorkClassCode);

                    string sql = $"insert LabourTimeEntry(MatchID, CompanyId, LogHeaderId, EmpNum, Billable, WorkClassId, Comments, TimeStamp) " +
                        $"values (-1, {Company.CurrentId}, {currHeaderId}, {temp.EmpNum}, '{project.Billable}', {wc.MatchId}, 'Loaded from template', getdate()); " +
                        $"Select CAST(SCOPE_IDENTITY() AS INT);";
                    Common.ExecuteScalar(sql);
                }
                return true;
            }

            return false;
        }

        public static int SqlInsert(int headerId, int empNum, int? level1Id, int? level2Id, bool billable, int workClassId, decimal? totalHours, decimal? billAmount)
        {
            string sql = $"insert LabourTimeEntry(MatchId, CompanyId, LogHeaderId, EmpNum, Level1Id, Level2Id, Billable, WorkClassId, Comments, TotalHours, BillAmount, TimeStamp) " +
                $"values(-1, {Company.CurrentId}, {headerId}, {empNum}, {StringEx.ToValueOrNull(level1Id)}, {StringEx.ToValueOrNull(level2Id)}, '{billable}', " +
                $"{workClassId}, '', {StringEx.ToValueOrNull(totalHours)}, {StringEx.ToValueOrNull(billAmount)}, getdate()); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(Common.ExecuteScalar(sql));
        }

        public static void SqlUpdate(int id, int empNum, int? level1Id, int? level2Id, bool billable, int workClassId, decimal? totalHours, decimal? billAmount)
        {
            string sql = $"update LabourTimeEntry set EmpNum={empNum}, Level1Id={StringEx.ToValueOrNull(level1Id)}, Level2Id={StringEx.ToValueOrNull(level2Id)}, Billable='{billable}', " +
                $"WorkClassId={workClassId}, TotalHours={StringEx.ToValueOrNull(totalHours)}, BillAmount={StringEx.ToValueOrNull(billAmount)}, TimeStamp=getdate() where Id={id} ";

            Common.ExecuteNonQuery(sql);
        }

        public static void SqlDelete(int id)
        {
            LabourTimeEntry curr = LabourTimeEntry.GetLabourEntry(id);

            string sql = $" delete LabourTimeEntry where id={id}";
            Common.ExecuteNonQuery(sql);

            sql = $"INSERT INTO DeleteHistory(TableName, MatchId, CompanyId, TimeStamp) values('LabourTimeEntry', {curr.MatchId}, {curr.CompanyId}, getdate())";
            Common.ExecuteNonQuery(sql);
        }

    }

    public class LabourTimeDetail     //WS_EMP_TimeClockHours
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int EntryId;
        public int TimeCodeId;
        public decimal EnterValue;
        public DateTime TimeStamp;

        public decimal Rate;        // need calc

        public static int SqlInsert(int entryId, int timecodeId, decimal? workHours)
        {
            string sql = $"Insert LabourTimeDetail(MatchId, CompanyId, EntryId, TimeCodeId, WorkHours, TimeStamp) " +
                $"values(-1, {Company.CurrentId}, {entryId}, {timecodeId}, {workHours ?? 0}, getdate()); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(Common.ExecuteScalar(sql));
        }

        public static void SqlInsertUpdate(int entryId, int timecodeId, decimal? workHours)
        {
            string sql = $"update LabourTimeDetail set WorkHours=workHours, TimeStamp=getdate() where EntryId={entryId} and TimeCodeId={timecodeId}; " +
                        $"IF(@@ROWCOUNT=0)" +
                            $"Insert LabourTimeDetail(MatchId, CompanyId, EntryId, TimeCodeId, WorkHours, TimeStamp) " +
                            $"values(-1, {Company.CurrentId}, {entryId}, {timecodeId}, {workHours ?? 0}, getdate()); ";

            Common.ExecuteNonQuery(sql);
        }
    }
}
