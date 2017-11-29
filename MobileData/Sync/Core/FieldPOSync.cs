using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MobileData
{
    public class FieldPOSync : CoreSync
    {
        protected override string TableName { get { return "FieldPO"; } }
        protected override string DisplayName { get { return "Field PO"; } }

        public FieldPOSync(int companyId) : base(companyId)
        {
        }

        public List<FieldPO> GetSendList()
        {
            string sql = $"select * from FieldPO where companyId={CompanyId} and FieldPOStatus='{(char)EnumSubmitStatus.Ready}'";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<FieldPO> list = table.Select().Select(r => new FieldPO(r)).ToList();
            list.ForEach(x => x.GetPODetails());

            return list;
        }

        public override async Task<SyncResult> Send(Guid token, int syncId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);
                    UpdateStatus(EnumTableSyncStatus.Sending);
                    SyncCoreMatch.SqlDelete(TableName);

                    List<FieldPO> list = GetSendList();
                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    foreach (FieldPO po in list)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync($"api/FieldPO?{query.ToString()}", po);
                        if (response.IsSuccessStatusCode)
                        {
                            string[] results = await response.Content.ReadAsAsync<string[]>();
                            AfterSendRecord(po.Id);
                            SyncCoreMatch.SqlInsert(TableName, po.Id, int.Parse(results[0]));
                        }
                        else
                        {
                            throw new Exception($"Post Response StatusCode={response.ReasonPhrase}");
                        }
                    }

                    UpdateStatus(EnumTableSyncStatus.CompleteSend);
                    return new SyncResult { Successful = true };
                }
            }
            catch (Exception e)
            {
                UpdateStatus(EnumTableSyncStatus.ErrorInSend);
                return new SyncResult { Successful = false, Task = TableName, Message = e.Message };
            }
        }

        public override void CommitSend()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Sending, EnumTableSyncStatus.CompleteSend }.Contains(SyncInfo.Status))
            {
                DataTable table = MobileCommon.ExecuteDataAdapter($"select Id from FieldPO where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Submiting}'");
                var idList = table.Select().Select(r => (int)r["Id"]);

                foreach (int id in idList)
                {
                    var match = SyncCoreMatch.GetMatch(TableName, id);
                    string sql = $"update FieldPO set SyncStatus='{EnumRecordSyncStatus.Submitted}', MatchID={match.MatchId}, FieldPOStatus='{(char)EnumSubmitStatus.Submitted}' where Id={id}";
                    MobileCommon.ExecuteNonQuery(sql);
                }

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["companyId"] = CompanyId.ToString();
                    query["syncId"] = CompanySyncProcess.GetSyncProcess(CompanyId, EnumSyncType.Core).SyncId.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/FieldPO?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<string[]> list = await response.Content.ReadAsAsync<List<string[]>>();
                        
                        list.ForEach( x => 
                        {
                            int matchId = int.Parse(x[0]);
                            BeforeReceiveRecord(matchId);
                            SyncCoreMatch.SqlUpdate(TableName, matchId, x[1]);
                        });

                        UpdateStatus(EnumTableSyncStatus.CompleteReceive);
                        return new SyncResult { Successful = true };
                    }
                    throw new Exception($"Response StatusCode={response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                UpdateStatus(EnumTableSyncStatus.ErrorInReceive);
                return new SyncResult { Successful = false, Task = TableName, Message = e.Message };
            }
        }

        public override void CommitReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive }.Contains(SyncInfo.Status))
            {
                DataTable table = MobileCommon.ExecuteDataAdapter($"select Id from FieldPO where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Updating}'");
                var idList = table.Select().Select(r => (int)r["Id"]);

                foreach (int id in idList)
                {
                    var match = SyncCoreMatch.GetMatch(TableName, id);
                    if (match != null)
                    {
                        string sql = $"update FieldPO set SyncStatus='{EnumRecordSyncStatus.Submitted}', PONum='{match.SyncMatch}' where Id={id}";
                        MobileCommon.ExecuteNonQuery(sql);
                    }
                }

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public override void RollbackReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive, EnumTableSyncStatus.ErrorInReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"update FieldPO set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
