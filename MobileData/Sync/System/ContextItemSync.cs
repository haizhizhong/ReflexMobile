using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class ContextItemSync : SystemSync
    {
        protected override string TableName { get { return "ContextItem"; } }
        protected override string DisplayName { get { return "Attachment Context Item"; } }

        public override async System.Threading.Tasks.Task<SyncResult> Receive()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    HttpResponseMessage response = await client.GetAsync("api/ContextItems");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<ContextItem> list = await response.Content.ReadAsAsync<List<ContextItem>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert ContextItem(ID, ContextGroupID, Name, WordMergeDSN, IsSystem, InSync) " +
                                    $"values({x.ID}, {x.ContextGroupID}, '{x.Name}', {StrEx.StrOrNull(x.WordMergeDSN)}, '{x.IsSystem}', 1)";
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
