using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileData
{
    public class ChangeOrderSync : ReceiveSync
    {
        protected override string TableName { get { return "ChangeOrder"; } }
        protected override string DisplayName { get { return "Change Order"; } }

        public ChangeOrderSync(int companyId) : base(companyId) 
        {
        }

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                ChangeOrder.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/ChangeOrders?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<ChangeOrder> list = await response.Content.ReadAsAsync<List<ChangeOrder>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert ChangeOrder(CompanyId, ProjectId, EstimateId, ChangeOrderNum, ChangeOrderName, InSync) " +
                              $"values({x.CompanyId}, {x.ProjectId}, {x.EstimateId}, {StrEx.ValueOrNull(x.ChangeOrderNum)}, '{x.ChangeOrderName}', 1)";
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
