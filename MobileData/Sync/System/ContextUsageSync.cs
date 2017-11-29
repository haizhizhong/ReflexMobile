using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class ContextUsageSync : SystemSync
    {
        protected override string TableName { get { return "ContextUsage"; } }
        protected override string DisplayName { get { return "Attachment Context Usage"; } }

        public override async System.Threading.Tasks.Task<SyncResult> Receive()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    HttpResponseMessage response = await client.GetAsync("api/ContextUsages");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<ContextUsage> list = await response.Content.ReadAsAsync<List<ContextUsage>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert ContextUsage(ID, ContextItemID, ContextGroupID, InSync) " +
                                    $"values({x.ID}, {x.ContextItemID}, {x.ContextGroupID}, 1)";
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
    }
}
