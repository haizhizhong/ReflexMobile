using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileData
{
    public class SysSecuritySync : SystemSync
    {
        protected override string TableName { get { return "Security"; } }
        protected override string DisplayName { get { return "Security"; } }

        public override async Task<SyncResult> Receive()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init();
                    HttpResponseMessage response = await client.GetAsync($"api/Security");

                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<Security> list = await response.Content.ReadAsAsync<List<Security>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Security(Function_ID, companyId, Department, InSync) values({x.Function_ID}, {x.CompanyId}, '{x.Department}', 1)";
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
