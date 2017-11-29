using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileData
{
    public class EquipmentGroupBillRateSync : ReceiveSync
    {
        protected override string TableName { get { return "EquipmentGroupBillRate"; } }
        protected override string DisplayName { get { return "Equipment Group Bill Rate"; } }

        public EquipmentGroupBillRateSync(int companyId) : base(companyId)
        {
        }

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                EquipmentGroupBillRate.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/EquipmentGroupBillRates?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<EquipmentGroupBillRate> list = await response.Content.ReadAsAsync<List<EquipmentGroupBillRate>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert EquipmentGroupBillRate(CompanyId, ProjectId, GroupCode, GroupType, BillCycle, BillRate, IsDefault, InSync) " +
                              $"values({x.CompanyId}, {StrEx.ValueOrNull(x.ProjectId)}, '{x.GroupCode}', '{(char)x.GroupType}', '{(char)x.BillCycle}', {x.BillRate}, '{x.IsDefault}', 1)";
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
