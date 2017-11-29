using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileData
{
    public class SupplierSync : ReceiveSync
    {
        protected override string TableName { get { return "Supplier"; } }
        protected override string DisplayName { get { return "Supplier"; } }

        public SupplierSync(int companyId) : base(companyId)
        {
        }

        public override async Task<SyncResult> Receive(Guid token)
        {
            try
            {
                Supplier.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/Suppliers?companyId={Company.CurrentId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<Supplier> list = await response.Content.ReadAsAsync<List<Supplier>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Supplier(CompanyId, SupplierCode, SupplierName, InSync) values({x.CompanyId}, '{StrEx.SqlEsc(x.SupplierCode)}', '{StrEx.SqlEsc(x.SupplierName)}', 1)";
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
                UpdateStatus( EnumTableSyncStatus.ErrorInReceive);
                return new SyncResult { Successful = false, Task = TableName, Message = e.Message };
            }
        }
    }
}
