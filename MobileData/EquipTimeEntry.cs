using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.Equipment;

namespace MobileData
{
    public class EquipTimeEntry
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int LogHeaderId;

        public string EqpNum;

        public int Level1Id;
        public int Level2Id;
        public bool Billable;       //?

        public decimal Quantity;
        public Equipment.EnumBillCycle BillCycle;
        public decimal BillAmount;
        public DateTime TimeStamp;

        public static EquipTimeEntry GetEquipEntry(int id)
        {
            DataTable table = Common.ExecuteDataAdapter($"select * from EquipTimeEntry where id={id}");
            EquipTimeEntry entry = new EquipTimeEntry
            {
                Id = (int)table.Rows[0]["Id"],
                MatchId = (int)table.Rows[0]["MatchId"],
                CompanyId = (int)table.Rows[0]["CompanyId"],
                LogHeaderId = (int)table.Rows[0]["LogHeaderId"],
                EqpNum = $"{table.Rows[0]["EqpNum"]}",
                Level1Id = table.Rows[0]["Level1Id"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["Level1Id"]),
                Level2Id = table.Rows[0]["Level2Id"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["Level2Id"]),
                Billable = (bool)table.Rows[0]["Billable"],
                Quantity = Convert.ToDecimal(table.Rows[0]["Quantity"]),
                BillCycle = (Equipment.EnumBillCycle)(Convert.ToChar(table.Rows[0]["BillCycle"])),
                BillAmount = table.Rows[0]["BillAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(table.Rows[0]["BillAmount"]),
                TimeStamp = (DateTime)table.Rows[0]["TimeStamp"]
            };

            return entry;
        }

        public static List<EquipTimeEntry> GetEquipEntryList(int logHeaderId)
        {
            List<EquipTimeEntry> list = new List<EquipTimeEntry>();

            DataTable table = Common.ExecuteDataAdapter($"select * from EquipTimeEntry where logHeaderId={logHeaderId}");
            table.Select().ToList().ForEach(r =>
            {
                list.Add(new EquipTimeEntry
                {
                    Id = (int)r["Id"],
                    MatchId = (int)r["MatchId"],
                    CompanyId = (int)r["CompanyId"],
                    LogHeaderId = (int)r["LogHeaderId"],
                    EqpNum = $"{r["EqpNum"]}",
                    Level1Id = r["Level1Id"] == DBNull.Value ? 0 : Convert.ToInt32(r["Level1Id"]),
                    Level2Id = r["Level2Id"] == DBNull.Value ? 0 : Convert.ToInt32(r["Level2Id"]),
                    Billable = (bool)r["Billable"],
                    Quantity = Convert.ToDecimal(r["Quantity"]),
                    BillCycle = (Equipment.EnumBillCycle)(Convert.ToChar(table.Rows[0]["BillCycle"])),
                    BillAmount = r["BillAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(r["BillAmount"]),
                    TimeStamp = (DateTime)r["TimeStamp"]
                });
            });

            return list;
        }

        public static bool CopyDataFromPrevDay(int projectId, DateTime currDate, int currHeaderId)
        {
            string sql = $"select top 1 h.id from LemLogHeader h " +
                $"join EquipTimeEntry e on h.Id = e.LogHeaderId where h.LogDate < '{currDate}' and ProjectID = {projectId} " +
                $"group by h.id, h.LogDate having count(e.Id) > 0 order by h.LogDate desc";

            object srcHeaderId = Common.ExecuteScalar(sql);
            if (srcHeaderId != null)
            {
                var srcList = GetEquipEntryList((int)srcHeaderId);
                foreach (var src in srcList)
                {
                    sql = $"insert EquipTimeEntry(MatchID, CompanyId, LogHeaderId, EqpNum, Level1Id, Level2Id, Billable, Quantity, BillCycle, BillAmount, TimeStamp) " +
                        $"values (-1, {src.CompanyId}, {currHeaderId}, {src.EqpNum}, {src.Level1Id}, {src.Level2Id}, '{src.Billable}', {src.Quantity}, '{(char)src.BillCycle}', {src.BillAmount}, getdate()); " +
                        $"Select CAST(SCOPE_IDENTITY() AS INT);";
                    Common.ExecuteNonQuery(sql);
                }
                return true;
            }

            return false;
        }

        public static bool CopyDataFromTemplate(int projectId, DateTime currDate, int currHeaderId)
        {
            var filtered = EquipmentTemplate.GetTemplate(projectId, currDate);
            if (filtered.Count > 0)
            {
                Project project = Project.GetProject(projectId);

                foreach (var temp in filtered)
                {
                    var pec = ProjectEquipmentClass.GetProjectEquipmentClass(temp.ProjectEquipClassId);
                    var equip = Equipment.ListForCompany().Single(x => x.Id == temp.EquipId);

                    string sql = $"insert EquipTimeEntry(MatchID, CompanyId, LogHeaderId, EqpNum, Billable, BillCycle, TimeStamp) " +
                        $"values (-1, {Company.CurrentId}, {currHeaderId}, {equip.EqpNum}, '{project.Billable}', '{pec.BillCycle}', getdate()); " +
                        $"Select CAST(SCOPE_IDENTITY() AS INT);";
                    Common.ExecuteScalar(sql);
                }
                return true;
            }

            return false;
        }

        public static decimal GetWeekHours(int projectId, int empNum, DateTime currDate)
        {
            int days = (currDate.DayOfWeek - Company.GetCompany(Company.CurrentId).WeekStart) % 7;
            DateTime firstDay = currDate.AddDays(-days);
            int regularTimeCodeId = TimeCode.ListForCompany().Single(x => x.BillingType == TimeCode.EnumBillingRateType.Regular).Id;

            string sql = $"select count(d.WorkHours) from LemLogHeader h " +
                $"join LabourTimeEntry e on h.Id = e.LogHeaderId " +
                $"join LabourTimeDetail d on e.Id = d.EntryId " +
                $"where h.project={projectId} and h.LogDate>={firstDay} and h.LogDate<{currDate} and e.EmpNum = {empNum} and d.TimeCodeId = {regularTimeCodeId}";

            return (decimal)Common.ExecuteScalar(sql);
        }

        public static int SqlInsert(int headerId, string eqpNum, int? level1Id, int? level2Id, bool billable, decimal quantity, EnumBillCycle billCycle, decimal? billAmount)
        {
            string sql = $"insert EquipTimeEntry(MatchId, CompanyId, LogHeaderId, EqpNum, Level1Id, Level2Id, Billable, Quantity, BillCycle, BillAmount, TimeStamp) " +
                $"values(-1, {Company.CurrentId}, {headerId}, {eqpNum}, {StringEx.ToValueOrNull(level1Id)}, {StringEx.ToValueOrNull(level2Id)}, '{billable}', " +
                $"{quantity}, '{(char)billCycle}', {StringEx.ToValueOrNull(billAmount)}, getdate()); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(Common.ExecuteScalar(sql));
        }

        public static void SqlDelete(int id)
        {
            var curr = EquipTimeEntry.GetEquipEntry(id);

            string sql = $" delete EquipTimeEntry where id={id}";
            Common.ExecuteNonQuery(sql);

            sql = $"INSERT INTO DeleteHistory(TableName, MatchId, CompanyId, TimeStamp) values('EquipTimeEntry', {curr.MatchId}, {curr.CompanyId}, getdate())";
            Common.ExecuteNonQuery(sql);
        }

        public static void SqlUpdate(int id, string eqpNum, int? level1Id, int? level2Id, bool billable, decimal quantity, EnumBillCycle billCycle, decimal? billAmount)
        {
            string sql = $"update EquipTimeEntry set EqpNum={eqpNum}, Level1Id={StringEx.ToValueOrNull(level1Id)}, Level2Id={StringEx.ToValueOrNull(level2Id)}, Billable='{billable}', " +
                $"Quantity={quantity}, BillCycle='{(char)billCycle}', BillAmount={StringEx.ToValueOrNull(billAmount)}, TimeStamp=getdate() where Id={id} ";

            Common.ExecuteNonQuery(sql);
        }
    }
}
