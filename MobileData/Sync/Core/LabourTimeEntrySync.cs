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
    public class LabourTimeEntrySync : CoreSync
    {
        protected override string TableName { get { return "LabourTimeEntry"; } }
        protected override string DisplayName { get { return "Labour Time Entry"; } }

        public LabourTimeEntrySync(int companyId) : base(companyId)
        {
        }

        public List<LabourTimeEntry> GetSendList()  
        {
            List<SyncCoreMatch> matchList = SyncCoreMatch.GetMatchList("LemHeader");
            string headerIds = StrEx.GetIdListText(matchList.Select(x => x.SourceId).ToList());

            string sql = $"select * from LabourTimeEntry where LogHeaderId in ({headerIds}) and (SyncStatus='{EnumRecordSyncStatus.NoSubmit}' or SyncStatus is null) and Deleted=0";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);

            List<LabourTimeEntry> list = table.Select().Select(r => new LabourTimeEntry(r)).ToList();
            list.ForEach(x => x.GetDetailList());
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

                    List<LabourTimeEntry> list = GetSendList();
                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    foreach (LabourTimeEntry item in list)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync($"api/LabourTimeEntry?{query.ToString()}", item);
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
                DataTable table = MobileCommon.ExecuteDataAdapter($"select Id from LabourTimeEntry where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Submiting}'");
                var idList = table.Select().ToList().Select(r => (int)r["Id"]);
                foreach (int id in idList)
                {
                    var match = SyncCoreMatch.GetMatch(TableName, id);
                    MobileCommon.ExecuteNonQuery($"update LabourTimeEntry set MatchID={match.MatchId}, SyncStatus='{EnumRecordSyncStatus.Submitted}' where Id={id}");
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
                    HttpResponseMessage response = await client.GetAsync($"api/LabourTimeEntry?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        var list = await response.Content.ReadAsAsync<List<LabourTimeEntry>>();
                        list.ForEach(x =>
                        {
                            BeforeReceiveRecord(x.MatchId);

                            string sql = $"insert LabourTimeEntry(MatchId, CompanyId, LogHeaderId, EmpNum, ChangeOrderId, Level1Id, Level2Id, Level3Id, Level4Id, Billable, Manual, WorkClassCode, IncludedHours, TotalHours, BillAmount, SyncStatus, Deleted) " +
                                    $"values({x.MatchId}, {x.CompanyId}, {x.HeaderId}, {x.EmpNum}, {StrEx.ValueOrNull(x.ChangeOrderId)}, {StrEx.ValueOrNull(x.Level1Id)}, {StrEx.ValueOrNull(x.Level2Id)}, " +
                                    $"{StrEx.ValueOrNull(x.Level3Id)}, {StrEx.ValueOrNull(x.Level4Id)}, '{x.Billable}', '{x.Manual}', '{x.WorkClassCode}', {StrEx.ValueOrNull(x.IncludedHours)}, {StrEx.ValueOrNull(x.TotalHours)}, {StrEx.ValueOrNull(x.BillAmount)}, '{EnumRecordSyncStatus.Receiving}', 0); " +
                                    $"Select CAST(SCOPE_IDENTITY() AS INT);";

                            int entryId = Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
                            foreach (var d in x.DetailList)
                            {
                                LabourTimeDetail.SqlInsert(entryId, d.TimeCodeId, d.BillRate, d.WorkHours, d.Amount);
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
                DataTable table = MobileCommon.ExecuteDataAdapter($"select Id from LabourTimeEntry where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}");
                var deleteList = table.Select().ToList().Select(r => (int)r["Id"]).ToList();
                deleteList.ForEach(x => LabourTimeEntry.SqlForceDelete(x));

                table = MobileCommon.ExecuteDataAdapter($"select * from LabourTimeEntry where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Receiving}'");
                List<LabourTimeEntry> list = table.Select().Select(r => new LabourTimeEntry(r)).ToList();

                foreach (var item in list)
                {
                    int localHeaderId = (int)MobileCommon.ExecuteScalar($"select id from LemHeader where MatchId={item.HeaderId} and CompanyId={CompanyId} and Deleted=0 ");
                    string sql = $"update LabourTimeEntry set SyncStatus='{EnumRecordSyncStatus.NoSubmit}', LogHeaderId={localHeaderId} where Id={item.Id}";
                    MobileCommon.ExecuteNonQuery(sql);
                }

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }

        public override void RollbackReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive, EnumTableSyncStatus.ErrorInReceive }.Contains(SyncInfo.Status))
            {
                DataTable table = MobileCommon.ExecuteDataAdapter($"select Id from LabourTimeEntry where SyncStatus='{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId}");
                List<int> idList = table.Select().ToList().Select(r => (int)r["Id"]).ToList();
                idList.ForEach(id => LabourTimeEntry.SqlForceDelete(id));

                string sql = $"update LabourTimeEntry set SyncStatus='{EnumRecordSyncStatus.NoSubmit}' where SyncStatus='{EnumRecordSyncStatus.Updating}' and CompanyId={CompanyId}";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
