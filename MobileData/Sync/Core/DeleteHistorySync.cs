using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MobileData
{
    public class DeleteHistorySync : CoreSync
    {
        protected override string TableName { get { return "DeleteHistory"; } }
        protected override string DisplayName { get { return "Delete History"; } }

        public DeleteHistorySync(int companyId) : base(companyId)
        {
        }

        public List<DeleteHistory> GetSendList()
        {
            string sql = $"select * from DeleteHistory where companyId={CompanyId} and (SyncStatus='{EnumRecordSyncStatus.NoSubmit}' or SyncStatus is null)";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<DeleteHistory> list = table.Select().Select(r => new DeleteHistory
            {
                Id = Convert.ToInt32(r["Id"]),
                CompanyId = CompanyId,
                TableName = Convert.ToString(r["TableName"]),
                MatchId = Convert.ToInt32(r["MatchId"]),
                TimeStamp = Convert.ToDateTime(r["TimeStamp"])
            }).ToList();

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

                    List<DeleteHistory> list = GetSendList();
                    var query = HttpUtility.ParseQueryString($"syncId={syncId}");
                    foreach (DeleteHistory item in list)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync($"api/DeleteHistory?{query.ToString()}", item);
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
                    query["syncId"] = CompanySyncProcess.GetSyncProcess(CompanyId, EnumSyncType.Core).SyncId.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/DeleteHistory?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<DeleteHistory> list = await response.Content.ReadAsAsync<List<DeleteHistory>>();
                        list.ForEach(x =>
                        {
                            string sql = $"INSERT INTO DeleteHistory(TableName, MatchId, CompanyId, TimeStamp, SyncStatus) " +
                                $"values('{x.TableName}', {x.MatchId}, {x.CompanyId}, '{DateTime.Now}', '{EnumRecordSyncStatus.Receiving}')";
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
                DataTable table = MobileCommon.ExecuteDataAdapter($"select * from DeleteHistory where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Receiving}'");
                List<DeleteHistory> list = table.Select().Select(r => new DeleteHistory(r)).ToList();

                list.ForEach(x => x.SqlExecute());
                DeleteHistory.UndeleteAll(CompanyId);

                MobileCommon.ExecuteNonQuery($"delete DeleteHistory where CompanyId={CompanyId} and SyncStatus='{EnumRecordSyncStatus.Receiving}'");

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
