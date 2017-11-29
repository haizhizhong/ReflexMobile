using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class EquipmentClassSync : ReceiveSync
    {
        protected override string TableName { get { return "EquipmentClass"; } }
        protected override string DisplayName { get { return "Equipment Class"; } }

        public EquipmentClassSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                EquipmentClass.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/EquipmentClasses?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<EquipmentClass> list = await response.Content.ReadAsAsync<List<EquipmentClass>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert EquipmentClass(CompanyId, Code, [Desc], InSync) " +
                              $"values({x.CompanyId}, '{x.Code}', '{x.Desc}', 1)";
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
