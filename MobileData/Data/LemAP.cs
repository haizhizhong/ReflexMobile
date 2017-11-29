using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LemAP //WS_FLEM_AP_GET
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int ProjectId;
        public DateTime InvoiceDate;

        public int? HeaderId;

        public string InvoiceNum;
        public string SupplierCode;
        public string PONum;

        public decimal InvoiceAmount;
        public decimal MarkupAmount;
        public decimal BillAmount;

        public List<LemAPDetail> DetailList;

        public LemAP()
        {
        }

        public LemAP(DataRow r)
        {
            Id = Convert.ToInt32(r["Id"]);
            MatchId = Convert.ToInt32(r["MatchId"]);
            CompanyId = Convert.ToInt32(r["CompanyId"]);
            ProjectId = Convert.ToInt32(r["ProjectId"]);
            HeaderId = ConvertEx.ToNullable<int>(r["LogHeaderId"]);
            InvoiceDate = Convert.ToDateTime(r["InvoiceDate"]);
            InvoiceNum = Convert.ToString(r["InvoiceNum"]);
            SupplierCode = Convert.ToString(r["SupplierCode"]);
            PONum = Convert.ToString(r["PONum"]);
            InvoiceAmount = Convert.ToDecimal(r["InvoiceAmount"]);
            MarkupAmount = Convert.ToDecimal(r["MarkupAmount"]);
            BillAmount = Convert.ToDecimal(r["BillAmount"]);

            DetailList = new List<LemAPDetail>();
        }

        public static List<LemAP> GetLemAP(int projectId, int logHeaderId)
        {
            string sql = $"select * from LemAP where CompanyId={Company.CurrentId} and ProjectId={projectId} and (LogHeaderId is null or LogHeaderId={logHeaderId})";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);

            List<LemAP> list = table.Select().Select(r => new LemAP(r)).ToList();
            list.ForEach(x => x.GetDetailList());

            return list;
        }

        public static void SqlUpdateLemAP(int id, int? logHeaderId)
        {
            if (logHeaderId == null)
            {
                int matchId = (int)MobileCommon.ExecuteScalar($"select isnull(matchid, 0) from LemAP where id={id} and SyncStatus='{EnumRecordSyncStatus.Submitted}'");
                if (matchId != 0)
                {
                    DeleteHistory.SqlInsert(DeleteHistory.LemAPUnselect, matchId);
                }
            }

            string sql = $"update LemAP set LogHeaderId={StrEx.ValueOrNull(logHeaderId)}, SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where Id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlForceDelete(int id)
        {
            MobileCommon.ExecuteNonQuery($"delete LemAPDetail where LemAPId={id}");
            MobileCommon.ExecuteNonQuery($"delete LemAP where id={id}");
        }

        public void GetDetailList()
        {
            DetailList.Clear();

            DataTable table = MobileCommon.ExecuteDataAdapter($"select * from LemAPDetail where LemAPId = {Id}");
            table.Select().ToList().ForEach(r => DetailList.Add(new LemAPDetail(r)));
        }

    }
}