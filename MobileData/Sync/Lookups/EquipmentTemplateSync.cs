using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;

namespace MobileData
{
    public class EquipmentTemplateSync : ReceiveSync
    {
        protected override string TableName { get { return "EquipmentTemplate"; } }
        protected override string DisplayName { get { return "Equipment Template"; } }

        public EquipmentTemplateSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                EquipmentTemplate.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/EquipmentTemplates?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<EquipmentTemplate> list = await response.Content.ReadAsAsync<List<EquipmentTemplate>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert EquipmentTemplate(MatchId, CompanyId, ProjectId, EqpNum, EquipClassCode, StartDate, EndDate, InSync) " +
                              $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, {x.EqpNum}, '{x.EquipClassCode}', {StrEx.StrOrNull(x.StartDate)}, {StrEx.StrOrNull(x.EndDate)}, 1)";
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
