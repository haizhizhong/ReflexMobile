using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class FieldPO
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public DateTime PODate;
        public string PONum;
        public string SupplierCode;
        public int ProjectId;
        public bool Billable;

        public decimal POAmount;
        public EnumSubmitStatus SubmitStatus;
        public int CreatorId;

        public List<FieldPODetail> DetailList;

        public const string MyName = "FieldPO";

        public FieldPO()
        {
        }

        public FieldPO(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            MatchId = Convert.ToInt32(row["MatchId"]);
            CompanyId = Convert.ToInt32(row["CompanyId"]);
            PODate = Convert.ToDateTime(row["PODate"]);
            PONum = Convert.ToString(row["PONum"]);
            SupplierCode = Convert.ToString(row["SupplierCode"]);
            ProjectId = Convert.ToInt32(row["ProjectId"]);
            Billable = Convert.ToBoolean(row["Billable"]);

            POAmount = Convert.ToDecimal(row["POAmount"]);
            SubmitStatus = ConvertEx.CharToEnum<EnumSubmitStatus>(row["FieldPOStatus"]);
            CreatorId = Convert.ToInt32(row["CreatorId"]);
        }

        public static List<FieldPO> GetAllPO()
        {
            string sql = $"select * from FieldPO where companyId={Company.CurrentId}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);

            return table.Select().Select(r => new FieldPO(r)).ToList();
        }

        public static FieldPO GetFieldPO(int id)
        {
            string sql = $"select * from FieldPO where id={id}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            return table.Select().Select( r=> new FieldPO(r)).Single();
        }

        public void GetPODetails()
        {
            string sql = $"select * from FieldPODetail where POId={Id}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            DetailList = table.Select().Select(r => new FieldPODetail(r)).ToList();
        }

        public static int SqlInsert(DateTime poDate, string poNum, string supplierCode, int projectId, bool billable)
        {
            string sql = $"insert FieldPO(MatchId, POdate, CompanyId, PONum, SupplierCode, projectId, Billable, POAmount, FieldPOStatus, CreatorId) " +
                $"values(-1, '{poDate}', {Company.CurrentId}, '{poNum.Replace("'", "''")}', '{supplierCode}', {projectId}, '{billable}', 0, '{(char)EnumSubmitStatus.Open}', {LoginUser.CurrUser.MatchId}); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
        }

        public static void SqlUpdate(int id, DateTime poDate, string poNum, string supplierCode, int projectId, bool billable)
        {
            string sql = $"update FieldPO set POdate='{poDate}', PONum='{StrEx.SqlEsc(poNum)}', SupplierCode='{supplierCode}', projectId={projectId}, " +
                $"Billable='{billable}', FieldPOStatus='{(char)EnumSubmitStatus.Open}', SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where Id={id}";

            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateAmount(int id, decimal poAmount)
        {
            string sql = $"update FieldPO set POAmount={poAmount}, FieldPOStatus='{(char)EnumSubmitStatus.Open}', SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where Id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateStatus(int id, EnumSubmitStatus status)
        {
            string sql = $"update FieldPO set FieldPOStatus='{(char)status}', SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where Id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlDelete(int id)
        {
            MobileCommon.ExecuteNonQuery($"delete FieldPODetail where POId={id}");
            MobileCommon.ExecuteNonQuery($"delete FieldPO where id={id}");

            var attachList = Attachment.GetAttachList(Attachment.FieldPOId, id);
            attachList.ForEach(x => Attachment.DeleteAttach(DeleteHistory.FieldPOAttach, x.RepositoryId));
        }
    }
}
