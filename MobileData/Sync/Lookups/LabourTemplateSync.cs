using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;

namespace MobileData
{
    public class LabourTemplateSync : ReceiveSync
    {
        protected override string TableName { get { return "LabourTemplate"; } }
        protected override string DisplayName { get { return "Labour Template"; } }

        public LabourTemplateSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                LabourTemplate.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/LabourTemplates?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<LabourTemplate> list = await response.Content.ReadAsAsync<List<LabourTemplate>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert LabourTemplate(MatchId, CompanyId, ProjectId, EmpNum, WorkClassCode, StartDate, EndDate, InSync)  " +
                              $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, {x.EmpNum}, '{x.WorkClassCode}', {StrEx.StrOrNull(x.StartDate)}, {StrEx.StrOrNull(x.EndDate)}, 1)";
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
