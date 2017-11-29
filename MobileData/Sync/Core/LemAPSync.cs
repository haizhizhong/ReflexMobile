using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MobileData
{
    public class LemAPSync : CoreSync 
    {
        protected override string TableName { get { return "LemAP"; } }
        protected override string DisplayName { get { return "LEM AP"; } }

        public LemAPSync(int companyId) : base(companyId)
        {
        }

        public List<LemAP> GetSendList()
        {
            new List<LemAP>();

            List<SyncCoreMatch> matchList = SyncCoreMatch.GetMatchList("LemHeader");
            string headerIds = StrEx.GetIdListText(matchList.Select(x => x.SourceId).ToList());

            string sql = $"select * from LemAP where companyId={CompanyId} and LogHeaderId in ({headerIds}) and (SyncStatus='{EnumRecordSyncStatus.NoSubmit}' or SyncStatus is null)";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<LemAP> list = table.Select().Select(r => new LemAP(r)).ToList();
            list.ForEach(x => x.HeaderId = matchList.Single(m => m.SourceId == x.HeaderId).MatchId);
            list.ForEach(x => x.GetDetailList());
            list.ForEach(x => x.DetailList.ForEach(d => d.LemAPId = x.MatchId));

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

                    HttpResponseMessage response;
                    List<LemAP> list = GetSendList();
                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    foreach (LemAP item in list)
                    {
                        response = await client.PostAsJsonAsync($"api/LemAP?{query.ToString()}", item);
                        response.EnsureSuccessStatusCode();
                        AfterSendRecord(item.Id);
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

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["companyId"] = CompanyId.ToString();
                    query["clientMac"] = MobileCommon.MachineMac;
                    HttpResponseMessage response = await client.GetAsync($"api/LemAP?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<LemAP> list = await response.Content.ReadAsAsync<List<LemAP>>();
                        list.ForEach(x =>
                        {
                            BeforeReceiveRecord(x.MatchId);

                            string sql = $"insert LemAp(MatchId, CompanyId, ProjectId, InvoiceDate, LogHeaderId, InvoiceNum, SupplierCode, PONum, InvoiceAmount, MarkupAmount, BillAmount, SyncStatus) " +
                                            $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, '{x.InvoiceDate}', null, '{x.InvoiceNum}', '{x.SupplierCode}', '{x.PONum}', {x.InvoiceAmount}, {x.MarkupAmount}, {x.BillAmount}, '{EnumRecordSyncStatus.Receiving}'); " +
                                        $"Select CAST(SCOPE_IDENTITY() AS INT);";

                            int mid = Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
                            foreach (var d in x.DetailList)
                            {
                                sql = $"insert LemAPDetail(MatchId, CompanyId, LemAPId, LineNum, Description, Reference, Amount, MarkupPercent, MarkupAmount, BillAmount, Level1Id, Level2Id, Level3Id, Level4Id) " +
                                        $"values({d.MatchId}, {d.CompanyId}, {mid}, {d.LineNum}, '{d.Description}', '{d.Reference}', {d.Amount}, {d.MarkupPercent}, {d.MarkupAmount}, {d.BillAmount}, " +
                                        $"{StrEx.ValueOrNull(d.Level1Id)}, {StrEx.ValueOrNull(d.Level2Id)}, {StrEx.ValueOrNull(d.Level3Id)}, {StrEx.ValueOrNull(d.Level4Id)});";
                                MobileCommon.ExecuteNonQuery(sql);
                            }
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
                string sql = $"select Id from LemAP where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}";
                DataTable table = MobileCommon.ExecuteDataAdapter(sql);
                List<int>idList = table.Select().ToList().Select(r => (int)r["Id"]).ToList();
                idList.ForEach(id => LemAP.SqlForceDelete(id));

                sql = $"update LemAP set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where SyncStatus='{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public override void RollbackReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive, EnumTableSyncStatus.ErrorInReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"select Id from LemAP where SyncStatus='{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId}";
                DataTable table = MobileCommon.ExecuteDataAdapter(sql);
                List<int> idList = table.Select().ToList().Select(r => (int)r["Id"]).ToList();
                idList.ForEach(id => LemAP.SqlForceDelete(id));

                sql = $"update LemAP set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
