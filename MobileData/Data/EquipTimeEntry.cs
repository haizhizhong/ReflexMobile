using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.Equipment;
using ReflexCommon;

namespace MobileData
{
    public class EquipTimeEntry
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int HeaderId;

        public string EqpNum;
        public int? EmpNum;
        public bool Billable;       //?
        public int? ChangeOrderId;       

        public int? Level1Id;
        public int? Level2Id;
        public int? Level3Id;
        public int? Level4Id;

        public decimal Quantity;
        public EnumBillCycle BillCycle;
        public decimal? BillAmount;

        public EquipTimeEntry()
        {
        }

        public EquipTimeEntry(DataRow row)
        {
            Id = (int)row["Id"];
            MatchId = (int)row["MatchId"];
            CompanyId = (int)row["CompanyId"];
            HeaderId = (int)row["LogHeaderId"];
            EqpNum = (string)row["EqpNum"];
            EmpNum = ConvertEx.ToNullable<int>(row["EmpNum"]);
            ChangeOrderId = ConvertEx.ToNullable<int>(row["ChangeOrderId"]);
            Level1Id = ConvertEx.ToNullable<int>(row["Level1Id"]);
            Level2Id = ConvertEx.ToNullable<int>(row["Level2Id"]);
            Level3Id = ConvertEx.ToNullable<int>(row["Level3Id"]);
            Level4Id = ConvertEx.ToNullable<int>(row["Level4Id"]);
            Billable = (bool)row["Billable"];
            Quantity = Convert.ToDecimal(row["Quantity"]);
            BillCycle = ConvertEx.CharToEnum<EnumBillCycle>(row["BillCycle"]);
            BillAmount = ConvertEx.ValueOrZero<decimal>(row["BillAmount"]);
        }

        public static EquipTimeEntry GetEquipEntry(int id)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from EquipTimeEntry where id={id}");

            return table.Select().Select( r=> new EquipTimeEntry(r)).Single();
        }

        public static List<EquipTimeEntry> GetEquipEntryList(int logHeaderId)
        {
            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from EquipTimeEntry where logHeaderId={logHeaderId} and deleted=0");
            return table.Select().Select(r => new EquipTimeEntry(r)).ToList();
        }

        public static bool CopyDataFromPrevDay(int projectId, DateTime currDate, int currHeaderId)
        {
            string sql = $"select top 1 id from LemHeader " +
                $"where LogDate<'{currDate.Date}' and ProjectID = {projectId} and CompanyId = {Company.CurrentId} and deleted = 0 " +
                $"order by LogDate desc";

            object srcHeaderId = MobileCommon.ExecuteScalar(sql);
            if (srcHeaderId != null)
            {
                var srcList = GetEquipEntryList((int)srcHeaderId);
                srcList.ForEach(src => SqlInsert(currHeaderId, src.EqpNum, src.EmpNum, src.ChangeOrderId, src.Level1Id, src.Level2Id, src.Level3Id, src.Level4Id, src.Billable, src.Quantity, src.BillCycle, src.BillAmount));
                return srcList.Any();
            }

            return false;
        }

        public static bool CopyDataFromTemplate(int projectId, DateTime currDate, int currHeaderId)
        {
            var filtered = EquipmentTemplate.GetTemplate(projectId, currDate);
            if (filtered.Count > 0)
            {
                Project project = Project.GetProject(projectId);

                foreach (var src in filtered)
                {
                    Equipment equip = GetEquipment(src.EqpNum);
                    Employee employee = (equip.OwnerType == EnumOwnerType.Employee) ? EquipmentAssignment.GetEmployee(equip.EqpNum, currDate) : null;
                    var pec = ProjectEquipmentClass.GetProjectEquipmentClass(projectId, src.EquipClassCode);
                    SqlInsert(currHeaderId, src.EqpNum, employee?.EmpNum, null, null, null, null, null, project.Billable, 0, pec.BillCycle, null);
                }
                return true;
            }

            return false;
        }

        public static int SqlInsert(int headerId, string eqpNum, int? empNum, int? changeOrderId, int? level1Id, int? level2Id, int? level3Id, int? level4Id, bool billable, decimal quantity, EnumBillCycle billCycle, decimal? billAmount)
        {
            string sql = $"insert EquipTimeEntry(MatchId, CompanyId, LogHeaderId, EqpNum, EmpNum, changeOrderId, Level1Id, Level2Id, Level3Id, Level4Id, Billable, Quantity, BillCycle, BillAmount, SyncStatus, Deleted) " +
                $"values(-1, {Company.CurrentId}, {headerId}, {eqpNum}, {StrEx.ValueOrNull(empNum)}, {StrEx.ValueOrNull(changeOrderId)}, {StrEx.ValueOrNull(level1Id)}, {StrEx.ValueOrNull(level2Id)}, {StrEx.ValueOrNull(level3Id)}, {StrEx.ValueOrNull(level4Id)}," +
                $" '{billable}', {quantity}, '{(char)billCycle}', {StrEx.ValueOrNull(billAmount)}, '{EnumRecordSyncStatus.NoSubmit}', 0); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
        }

        public static void DeleteEntry(int id)
        {
            var curr = EquipTimeEntry.GetEquipEntry(id);

            if (curr.MatchId != -1)
            {
                MobileCommon.ExecuteNonQuery($"update EquipTimeEntry set Deleted=1 where id={id}");
                DeleteHistory.SqlInsert(DeleteHistory.EquipTimeEntry, curr.MatchId);
            }
            else
            {
                SqlForceDelete(id);
            }
        }

        public static void SqlForceDelete(int id)
        {
            MobileCommon.ExecuteNonQuery($"delete EquipTimeEntry where id={id}");
        }

        public static void SqlUpdate(int id, string eqpNum, int? empNum, int? changeOrderId, int? level1Id, int? level2Id, int? level3Id, int? level4Id, bool billable, decimal quantity, EnumBillCycle billCycle, decimal? billAmount)
        {
            string sql = $"update EquipTimeEntry set EqpNum={eqpNum}, EmpNum={StrEx.ValueOrNull(empNum)}, Billable='{billable}', ChangeOrderId={StrEx.ValueOrNull(changeOrderId)}, " +
                $"Level1Id={StrEx.ValueOrNull(level1Id)}, Level2Id={StrEx.ValueOrNull(level2Id)}, Level3Id={StrEx.ValueOrNull(level3Id)}, Level4Id={StrEx.ValueOrNull(level4Id)}, " +
                $"Quantity={quantity}, BillCycle='{(char)billCycle}', BillAmount={StrEx.ValueOrNull(billAmount)}, SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where Id={id} ";

            MobileCommon.ExecuteNonQuery(sql);
        }
    }
}
