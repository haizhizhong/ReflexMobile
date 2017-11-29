using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class ContextGroupSync : SystemSync
    {
        protected override string TableName { get { return "ContextGroup"; } }
        protected override string DisplayName { get { return "Attachment Context Group"; } }

        public override async System.Threading.Tasks.Task<SyncResult> Receive()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    HttpResponseMessage response = await client.GetAsync("api/ContextGroups");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<ContextGroup> list = await response.Content.ReadAsAsync<List<ContextGroup>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert ContextGroup(ID, Name, IsSystem, InSync) " +
                                    $"values({x.ID}, '{x.Name}', '{x.IsSystem}', 1)";
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
