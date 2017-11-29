using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;

namespace MobileData
{
    public class ProjectSync : ReceiveSync
    {
        protected override string TableName { get { return "Project"; } }
        protected override string DisplayName { get { return "Project"; } }

        public ProjectSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                Project.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/Projects?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<Project> list = await response.Content.ReadAsAsync<List<Project>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Project(MatchId, CompanyId, Name, Code, CustomerId, CustomerCode, CustomerName, CustomerAddress, POReference, SiteLocation, StartDate, EstCompletionDate, " +
                                $"SiteAddress, SiteCity, SiteState, SiteZip, CustomerAddress2, CustomerAddress3, CustomerCity, CustomerState, CustomerZip, ProjectExtendedDescription, Billable, InSync) " +
                              $"values({x.MatchId}, {x.CompanyId}, '{x.Name}', {x.Code}, {x.CustomerId}, '{x.CustomerCode}', '{x.CustomerName}', '{x.CustomerAddress}', {StrEx.StrOrNull(x.POReference)}, '{x.SiteLocation}', {StrEx.StrOrNull(x.StartDate)}, {StrEx.StrOrNull(x.EstCompletionDate)}, " +
                              $"'{x.SiteAddress}', '{x.SiteCity}', '{x.SiteState}', '{x.SiteZip}', '{x.CustomerAddress2}', '{x.CustomerAddress3}', '{x.CustomerCity}', '{x.CustomerState}', '{x.CustomerZip}', '{StrEx.SqlEsc(x.ProjectExtendedDescription)}', '{x.Billable}', 1)";
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
