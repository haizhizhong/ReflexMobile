using System.Net.Http;
using System.Collections.Generic;
using System;

namespace MobileData
{
    public class ProjectEquipmentClassSync : ReceiveSync
    {
        protected override string TableName { get { return "ProjectEquipmentClass"; } }
        protected override string DisplayName { get { return "Project Equipment Class"; } }

        public ProjectEquipmentClassSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                ProjectEquipmentClass.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/ProjectEquipmentClasses?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<ProjectEquipmentClass> list = await response.Content.ReadAsAsync<List<ProjectEquipmentClass>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert ProjectEquipmentClass(MatchId, companyId, ProjectId, ClassCode, Schedulable, UseOverride, BillRate, BillCycle, InSync) " +
                              $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, '{x.ClassCode}', '{x.Schedulable}', '{x.UseOverride}', {x.BillRate}, '{(char)x.BillCycle}', 1)";
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
