using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class EquipmentCategorySync : ReceiveSync
    {
        protected override string TableName { get { return "EquipmentCategory"; } }
        protected override string DisplayName { get { return "Equipment Category"; } }

        public EquipmentCategorySync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                EquipmentCategory.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/EquipmentCategories?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<EquipmentCategory> list = await response.Content.ReadAsAsync<List<EquipmentCategory>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert EquipmentCategory(CompanyId, Code, [Desc], InSync) " +
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
