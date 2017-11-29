using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ReflexCommon;

namespace MobileData
{
    public class SecurityFunctionSync : SystemSync
    {
        protected override string TableName { get { return "SecurityFunction"; } }
        protected override string DisplayName { get { return "Security Function"; } }

        public override async Task<SyncResult> Receive()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();
                    HttpResponseMessage response = await client.GetAsync($"api/SecurityFunction");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<SecurityFunction> list = await response.Content.ReadAsAsync<List<SecurityFunction>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert SecurityFunction(Id, ParentId, Description, FieldServices, InSync) values({x.Id}, {StrEx.ValueOrNull(x.ParentId)}, '{x.Description}', '{x.FieldServices}', 1)";
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
