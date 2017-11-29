using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ReflexCommon;

namespace MobileData
{
    public class EquipTimeEntrySync : CoreSync
    {
        protected override string TableName { get { return "EquipTimeEntry"; } }
        protected override string DisplayName { get { return "Equipment Time Entry"; } }

        public EquipTimeEntrySync(int companyId) : base(companyId)
        {
        }

        public List<EquipTimeEntry> GetSendList()       // must after sent headers 
        {
            List<SyncCoreMatch> matchList = SyncCoreMatch.GetMatchList("LemHeader");
            string headerIds = StrEx.GetIdListText(matchList.Select(x => x.SourceId).ToList());

            string sql = $"select * from EquipTimeEntry where LogHeaderId in ({headerIds}) and (SyncStatus='{EnumRecordSyncStatus.NoSubmit}' or SyncStatus is null) and Deleted=0";

            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<EquipTimeEntry> list = table.Select().Select(r => new EquipTimeEntry(r)).ToList();
            list.ForEach(x => x.HeaderId = matchList.Single(m => m.SourceId == x.HeaderId).MatchId);

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

                    List<EquipTimeEntry> list = GetSendList();
                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    foreach (EquipTimeEntry item in list)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync($"api/EquipTimeEntry?{query.ToString()}", item);
                        if (response.IsSuccessStatusCode)
                        {
                            int matchId = await response.Content.ReadAsAsync<int>();
                            AfterSendRecord(item.Id);
                            SyncCoreMatch.SqlInsert(TableName, item.Id, matchId);
                        }
                        else
                        {
                            throw new Exception($"Post Response StatusCode={response.StatusCode}");
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
                DataTable table = MobileCommon.ExecuteDataAdapter($"select Id from EquipTimeEntry where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Submiting}'");
                var idList = table.Select().ToList().Select(r => (int)r["Id"]);
                foreach (int id in idList)
                {
                    var match = SyncCoreMatch.GetMatch(TableName, id);
                    MobileCommon.ExecuteNonQuery($"update {TableName} set MatchID={match.MatchId}, SyncStatus='{EnumRecordSyncStatus.Submitted}' where Id={id}");
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
                    query["clientMac"] = MobileCommon.MachineMac;
                    query["contactId"] = LoginUser.CurrUser.MatchId.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/EquipTimeEntry?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        var list = await response.Content.ReadAsAsync<List<EquipTimeEntry>>();
                        list.ForEach(x =>
                        {
                            BeforeReceiveRecord(x.MatchId);
                            string sql = $"insert EquipTimeEntry(MatchID, CompanyId, LogHeaderId, EqpNum, ChangeOrderId, Level1Id, Level2Id, Level3Id, Level4Id, Billable, Quantity, BillCycle, BillAmount, SyncStatus, Deleted) " +
                                    $"values({x.MatchId}, {x.CompanyId}, {x.HeaderId}, '{x.EqpNum}', {StrEx.ValueOrNull(x.ChangeOrderId)}, {StrEx.ValueOrNull(x.Level1Id)}, {StrEx.ValueOrNull(x.Level2Id)}, " +
                                    $"{StrEx.ValueOrNull(x.Level3Id)}, {StrEx.ValueOrNull(x.Level4Id)}, '{x.Billable}', {x.Quantity}, '{(char)x.BillCycle}', {StrEx.ValueOrNull(x.BillAmount)}, '{EnumRecordSyncStatus.Receiving}', 0)";
                            MobileCommon.ExecuteNonQuery(sql);
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
                string sql = $"delete EquipTimeEntry where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                DataTable table = MobileCommon.ExecuteDataAdapter($"select * from EquipTimeEntry where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Receiving}'");
                List<EquipTimeEntry> list = table.Select().Select(r => new EquipTimeEntry(r)).ToList();

                foreach (var item in list)
                {
                    int localHeaderId = (int)MobileCommon.ExecuteScalar($"select id from LemHeader where MatchId={item.HeaderId} and CompanyId={CompanyId} and Deleted=0");
                    sql = $"update EquipTimeEntry set SyncStatus='{EnumRecordSyncStatus.NoSubmit}', LogHeaderId={localHeaderId} where Id={item.Id}";
                    MobileCommon.ExecuteNonQuery(sql);
                }

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
