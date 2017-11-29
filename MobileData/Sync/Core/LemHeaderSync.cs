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
    public class LemHeaderSync : CoreSync
    {
        protected override string TableName { get { return "LemHeader"; } }
        protected override string DisplayName { get { return "LEM Header"; } }

        public LemHeaderSync(int companyId) : base(companyId)
        {
        }

        public List<LemHeader> GetSendList()
        {
            string sql = $"select * from LemHeader where CompanyId={CompanyId} and SubmitStatus='{(char)EnumSubmitStatus.Ready}' and Deleted=0";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<LemHeader> list = table.Select().Select(r => new LemHeader(r)).ToList();
            list.ForEach(x => x.BillAmount = x.GetLemTotal());

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

                    List<LemHeader> list = GetSendList();
                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    foreach (LemHeader item in list)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync($"api/LemHeader?{query.ToString()}", item);
                        if (response.IsSuccessStatusCode)
                        {
                            string[] results = await response.Content.ReadAsAsync<string[]>();
                            AfterSendRecord(item.Id);
                            SyncCoreMatch.SqlInsert(TableName, item.Id, int.Parse(results[0]), results[1]);
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
                DataTable table = MobileCommon.ExecuteDataAdapter($"select Id from LemHeader where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Submiting}'");
                var idList = table.Select().ToList().Select(r => (int)r["Id"]);

                foreach (int id in idList)
                {
                    var match = SyncCoreMatch.GetMatch(TableName, id);
                    string sql = $"update LemHeader set SyncStatus='{EnumRecordSyncStatus.Submitted}', MatchID={match.MatchId}, LemNum='{match.SyncMatch}', EmailData=null, " +
                        $"SubmitStatus='{(char)EnumSubmitStatus.Submitted}' where Id={id}";
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
                    query["clientMac"] = MobileCommon.MachineMac;
                    query["contactId"] = LoginUser.CurrUser.MatchId.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/LemHeader?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        var list = await response.Content.ReadAsAsync<List<LemHeader>>();

                        list.ForEach(x =>
                        {
                            BeforeReceiveRecord(x.MatchId);

                            string sql = $"insert LemHeader(MatchId, CompanyId, LogDate, LogStatus, SubmitStatus, ProjectId, LemNum, LEM_Desc, ApprovalComments, CreatorId, SyncStatus, Deleted) " +
                                    $"values({x.MatchId}, {x.CompanyId}, '{x.LogDate}', '{(char)x.LogStatus}', '{(char)EnumSubmitStatus.Open}', {x.ProjectId}, '{x.LemNum}', '{StrEx.SqlEsc(x.Description)}', '{StrEx.SqlEsc(x.ApprovalComments)}', {x.CreatorId}, '{EnumRecordSyncStatus.Receiving}', 0);";

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
                DataTable table = MobileCommon.ExecuteDataAdapter($"select * from LemHeader where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Updating}'");
                List<LemHeader> oldList = table.Select().Select(r => new LemHeader(r)).ToList();
                oldList.ForEach(r => LemHeader.SqlForceDelete(r.Id));

                table = MobileCommon.ExecuteDataAdapter($"select * from LemHeader where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Receiving}'");
                List<LemHeader> newList = table.Select().Select(r => new LemHeader(r)).ToList();

                foreach (var item in oldList)
                {
                    int newHeaderId = newList.Single(x => x.MatchId == item.MatchId).Id;
                    string sql = $"update LabourTimeEntry set LogHeaderId={newHeaderId} where SyncStatus<>'{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId} and LogHeaderId={item.Id}";
                    MobileCommon.ExecuteNonQuery(sql);

                    sql = $"update EquipTimeEntry set LogHeaderId={newHeaderId} where SyncStatus<>'{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId} and LogHeaderId={item.Id}";
                    MobileCommon.ExecuteNonQuery(sql);

                    sql = $"update LemAP set LogHeaderId={newHeaderId} where SyncStatus<>'{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId} and LogHeaderId={item.Id}";
                    MobileCommon.ExecuteNonQuery(sql);

                    sql = $"update CFS_FileLink set IdValue={newHeaderId} where SyncStatus<>'{EnumRecordSyncStatus.Receiving}' and CompanyId={CompanyId} and IdValue={item.Id}";
                    MobileCommon.ExecuteNonQuery(sql);
                }

                base.CommitReceive();
            }
        }
    }
}
