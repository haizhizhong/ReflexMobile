using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MobileData
{
    public enum EnumSubmitStatus
    {
        Open = 'O',
        Ready = 'R',
        Submitted = 'S'
    };


    public enum EnumLogStatus
    {
        Pending = 'P',
        Declined = 'D',
        Approved = 'A',
        Billed = 'B',
        Quarantine = 'Q'
    }

    public class LemHeader         //  WS_PCDL_LogHeader, WS_PCDL_LogEntry
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public DateTime LogDate;
        public EnumLogStatus LogStatus;
        public EnumSubmitStatus SubmitStatus;
        public string LemNum;
        public int ProjectId;
        public int CreatorId;
        public string Description;
        public string ApprovalComments;

        public byte[] EmailData;

        public decimal BillAmount;

        public LemHeader()
        {
        }

        public LemHeader(DataRow row)
        {
            Id = (int)row["Id"];
            MatchId = (int)row["MatchId"];
            CompanyId = (int)row["CompanyId"];
            LogDate = Convert.ToDateTime(row["LogDate"]);
            LogStatus = ConvertEx.CharToEnum<EnumLogStatus>(row["LogStatus"]);
            SubmitStatus = ConvertEx.CharToEnum<EnumSubmitStatus>(row["SubmitStatus"]);
            ProjectId = (int)row["ProjectId"];
            LemNum = Convert.ToString(row["LemNum"]);
            CreatorId = Convert.ToInt32(row["CreatorId"]);
            Description = Convert.ToString(row["LEM_Desc"]);
            ApprovalComments = Convert.ToString(row["ApprovalComments"]);
            EmailData = ConvertEx.ToNullableObj<byte[]>(row["EmailData"]);
        }

        public static List<LemHeader> GetLogHeaderList(int? projectId, DateTime? fromDate, DateTime? toDate, EnumLogStatus? status, string lemNum)
        {
            string filterText = "0";
            Project.AccessibleList().Select(x => x.MatchId).ToList().ForEach(id => filterText += $",{id}");

            string sql = $"select * from LemHeader where CompanyId={Company.CurrentId} and deleted=0 and ProjectId in ({filterText})";
            sql += projectId == null ? "" : $" and ProjectId={projectId}";
            sql += fromDate == null ? "" : $" and LogDate>='{fromDate}'";
            sql += toDate == null ? "" : $" and LogDate<='{toDate}'";
            sql += status == null ? "" : $" and LogStatus='{(char)status}'";
            sql += lemNum == null ? "" : $" and LemNum='{lemNum}'";

            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<LemHeader> list = table.Select().Select(r => new LemHeader(r)).ToList();

            return list;
        }

        public static List<string> GetAllLemNumber()
        {
            string sql = $"select LemNum from LemHeader where CompanyId={Company.CurrentId} and deleted=0";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            return table.Select().Select(r => Convert.ToString(r["LemNum"])).ToList();
        }

        public static DataTable GetCostCodeSummary(List<int> headerIds)
        {
            string idText = StrEx.GetIdListText(headerIds);

            string sql = $"select e.EmpNum, WorkClassCode, e.Billable, ProjectId, ChangeOrderId, Level1Id, Level2Id, Level3Id, Level4Id, d.TimeCodeId, Sum(d.WorkHours) SumWorkHour, Sum(d.Amount) SumAmount " +
                $"from Lemheader h join LabourTimeEntry e on e.LogHeaderId = h.id " +
                $"join LabourTimeDetail d on e.id = d.EntryId " +
                $"where h.Deleted = 0 and e.Deleted = 0 and h.Id in ({idText})" +
                $"group by e.EmpNum, e.WorkClassCode, e.Billable, ProjectId, ChangeOrderId, Level1Id, Level2Id, Level3Id, Level4Id, d.TimeCodeId ";
            return MobileCommon.ExecuteDataAdapter(sql);
        }


        public static DataTable GetEmployeeSummary(List<int> headerIds)
        {
            string idText = StrEx.GetIdListText(headerIds);

            string sql = $"select e.EmpNum, WorkClassCode, ProjectId, d.TimeCodeId, Sum(d.WorkHours) SumWorkHour, Sum(d.Amount) SumAmount " +
                $"from Lemheader h join LabourTimeEntry e on e.LogHeaderId= h.id " +
                $"join LabourTimeDetail d on e.id= d.EntryId " +
                $"where h.Deleted = 0 and e.Deleted = 0 and h.Id in ({idText})" +
                $"group by e.EmpNum, e.WorkClassCode, ProjectId, d.TimeCodeId ";
            return MobileCommon.ExecuteDataAdapter(sql);
        }

        public static LemHeader GetLogHeader(int id)
        {
            string sql = $"select * from LemHeader where Id={id}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            return table.Select().Select(r => new LemHeader(r)).FirstOrDefault();
        }

        public static bool CheckLevelCodeValid(int id)
        {
            int max = Company.GetCurrCompany().MaxLevelCode;
            if ((int)MobileCommon.ExecuteScalar($"select count(*) from LabourTimeEntry where Level{max}Id is null and LogHeaderId = {id} and deleted=0") > 0)
                return false;
            if ((int)MobileCommon.ExecuteScalar($"select count(*) from EquipTimeEntry where Level{max}Id is null and LogHeaderId = {id} and deleted=0") > 0)
                return false;

            return true;
        }

        public bool CheckEditable()
        {
            return CheckEditable(LogStatus);
        }

        public static bool CheckEditable(EnumLogStatus logStatus)
        {
            return new List<EnumLogStatus> { EnumLogStatus.Billed, EnumLogStatus.Quarantine }.Contains(logStatus) == false;
        }

        public static bool CheckHasEntry(int id)
        {
            if ((int)MobileCommon.ExecuteScalar($"select count(*) from LabourTimeEntry where LogHeaderId = {id} and deleted=0") > 0)
                return true;
            if ((int)MobileCommon.ExecuteScalar($"select count(*) from EquipTimeEntry where LogHeaderId = {id} and deleted=0") > 0)
                return true;
            if ((int)MobileCommon.ExecuteScalar($"select count(*) from LemAP where LogHeaderId = {id}") > 0)
                return true;

            return false;
        }

        public decimal GetLemTotal()
        {
            string sql = $"select isnull(SUM(BillAmount),0.0) from LabourTimeEntry where LogHeaderId = {Id} and deleted=0";
            decimal laboutTotal = Convert.ToDecimal(MobileCommon.ExecuteScalar(sql));

            sql = $"select isnull(SUM(BillAmount),0.0) from EquipTimeEntry where LogHeaderId = {Id} and deleted=0";
            decimal equipTotal = Convert.ToDecimal(MobileCommon.ExecuteScalar(sql));

            sql = $"select isnull(SUM(BillAmount),0.0) from LemAp where LogHeaderId = {Id}";
            decimal apTotal = Convert.ToDecimal(MobileCommon.ExecuteScalar(sql));

            return laboutTotal + equipTotal + apTotal;
        }

        public static int SqlInsert(DateTime logDate, int projectId, string lemNum, string desc)
        {
            string sql = $"insert LemHeader(MatchId, CompanyId, LogDate, LogStatus, SubmitStatus, ProjectId, LemNum, LEM_Desc, CreatorId, Deleted) " +
                $"values(-1, {Company.CurrentId}, '{logDate}', '{(char)EnumLogStatus.Pending}', '{(char)EnumSubmitStatus.Open}', {projectId}, '{lemNum}', '{StrEx.SqlEsc(desc)}', {LoginUser.CurrUser.MatchId}, 0); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
        }

        public static void SqlDelete(int id)
        {
            var curr = LemHeader.GetLogHeader(id);
            if (curr.MatchId != -1)
            {
                string sql = $"update LemHeader set deleted=1 where id={id}";
                MobileCommon.ExecuteNonQuery(sql);

                DeleteHistory.SqlInsert(DeleteHistory.LemHeader, curr.MatchId);

                var labourList = LabourTimeEntry.GetLabourEntryList(id);
                labourList.ForEach(x => LabourTimeEntry.DeleteEntry(x.Id));

                var equipList = EquipTimeEntry.GetEquipEntryList(id);
                equipList.ForEach(x => EquipTimeEntry.DeleteEntry(x.Id));

                var attachList = Attachment.GetAttachList(Attachment.LemHeaderId, id);
                attachList.ForEach(x => Attachment.DeleteAttach(DeleteHistory.LemHeaderAttach, x.RepositoryId));
            }
            else
            {
                SqlForceDelete(id);
            }
        }

        public static void SqlForceDelete(int id)
        {
            string sql = $"delete LemHeader where id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdate(int id, DateTime logDate, int projectId, EnumLogStatus status, string desc)
        {
            string sql = $"Update LemHeader set LogDate='{logDate}', ProjectId={projectId}, LogStatus='{(char)status}', SubmitStatus='{(char)EnumSubmitStatus.Open}', LEM_Desc='{StrEx.SqlEsc(desc)}' where id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateSubmitStatus(int id, EnumSubmitStatus status)
        {
            string sql = $"Update LemHeader set SubmitStatus='{(char)status}' where id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateEmail(int id, byte[] email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(MobileCommon.MobileDB))
                {
                    con.Open();
                    string sql = $"Update LemHeader set EmailData=@Email where id={id}";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlParameter param = cmd.Parameters.Add("@Email", SqlDbType.VarBinary);
                        param.Value = email;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo("Sql Error: " + e);
            }
        }
    }
}
