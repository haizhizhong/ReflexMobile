using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;
using System.Web;

namespace MobileData
{
    public class CostCodeMappingSync : ReceiveSync
    {
        protected override string TableName { get { return "CostCodeMapping"; } }
        protected override string DisplayName { get { return "Cost Code Mapping"; } }

        public CostCodeMappingSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["contactId"] = LoginUser.CurrUser.MatchId.ToString();
                    query["companyId"] = CompanyId.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/CostCodeMapping?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<CostCodeMapping> list = await response.Content.ReadAsAsync<List<CostCodeMapping>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert CostCodeMapping(CompanyId, ProjectId, MappingId, MappingCode, InSync) " +
                              $"values({x.CompanyId}, {x.ProjectId}, {x.MappingId}, '{StrEx.SqlEsc(x.MappingCode)}', 1)";
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
