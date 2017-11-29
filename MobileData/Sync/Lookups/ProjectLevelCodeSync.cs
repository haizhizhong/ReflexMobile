using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

namespace MobileData
{
    public class ProjectLevelCodeSync : ReceiveSync
    {
        protected override string TableName { get { return "ProjectLevelCode"; } }
        protected override string DisplayName { get { return "Project Level Code"; } }

        public ProjectLevelCodeSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                ProjectLevelCode.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["contactId"] = LoginUser.CurrUser.MatchId.ToString();
                    query["companyId"] = CompanyId.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/ProjectLevelCode?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<ProjectLevelCode> list = await response.Content.ReadAsAsync<List<ProjectLevelCode>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert ProjectLevelCode(ProjectId, CompanyId, Level1Id, Level2Id, Level3Id, Level4Id, InSync) " +
                            $"values({x.ProjectId}, {x.CompanyId}, {StrEx.ValueOrNull(x.Level1Id)}, {StrEx.ValueOrNull(x.Level2Id)}, {StrEx.ValueOrNull(x.Level3Id)}, {StrEx.ValueOrNull(x.Level4Id)}, 1 )";
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
