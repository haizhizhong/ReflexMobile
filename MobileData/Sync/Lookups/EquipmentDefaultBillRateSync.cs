using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileData
{
    public class EquipmentDefaultBillRateSync : ReceiveSync
    {
        protected override string TableName { get { return "EquipmentDefaultBillRate"; } }
        protected override string DisplayName { get { return "Equipment Default Bill Rates"; } }

        public EquipmentDefaultBillRateSync(int companyId) : base(companyId)
        {
        }

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                EquipmentDefaultBillRate.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/EquipmentDefaultBillRates?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<EquipmentDefaultBillRate> list = await response.Content.ReadAsAsync<List<EquipmentDefaultBillRate>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert EquipmentDefaultBillRate(CompanyId, GroupType, BillCycle, BillRate, IsDefault, InSync) " +
                              $"values({x.CompanyId}, '{(char)x.GroupType}', '{(char)x.BillCycle}', {x.BillRate}, '{x.IsDefault}', 1)";
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
