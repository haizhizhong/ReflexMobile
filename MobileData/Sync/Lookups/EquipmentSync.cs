using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;

namespace MobileData
{
    public class EquipmentSync : ReceiveSync
    {
        protected override string TableName { get { return "Equipment"; } }
        protected override string DisplayName { get { return "Equipment"; } }

        public EquipmentSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                Equipment.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/Equipments?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<Equipment> list = await response.Content.ReadAsAsync<List<Equipment>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Equipment(EqpNum, CompanyId, AssetCode, [Desc], ClassCode, CategoryCode, OwnerType, InSync) " +
                              $"values('{x.EqpNum}', {x.CompanyId}, '{StrEx.SqlEsc(x.AssetCode)}', '{StrEx.SqlEsc(x.Desc)}', '{StrEx.SqlEsc(x.ClassCode)}', '{StrEx.SqlEsc(x.CategoryCode)}', '{(char)x.OwnerType}', 1)";
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
