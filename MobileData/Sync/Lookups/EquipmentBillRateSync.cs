using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static MobileData.Equipment;

namespace MobileData
{
    public class EquipmentBillRateSync : ReceiveSync
    {
        protected override string TableName { get { return "EquipmentBillRate"; } }
        protected override string DisplayName { get { return "Equipment Bill Rate"; } }

        public EquipmentBillRateSync(int companyId) : base(companyId) 
        {
        }

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/EquipmentBillRates?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<EquipmentBillRate> list = await response.Content.ReadAsAsync<List<EquipmentBillRate>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert EquipmentBillRate(CompanyId, EqpNum, BillCycle, BillRate, IsDefault, InSync) " +
                              $"values({x.CompanyId}, '{x.EqpNum}', '{(char)x.BillCycle}', {x.BillRate}, '{x.IsDefault}', 1)";
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
