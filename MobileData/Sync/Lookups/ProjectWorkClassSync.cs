using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;

namespace MobileData
{
    public class ProjectWorkClassSync : ReceiveSync
    {
        protected override string TableName { get { return "ProjectWorkClass"; } }
        protected override string DisplayName { get { return "Project Work Class"; } }

        public ProjectWorkClassSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                ProjectWorkClass.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/ProjectWorkClasses?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<ProjectWorkClass> list = await response.Content.ReadAsAsync<List<ProjectWorkClass>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert ProjectWorkClass(MatchId, CompanyId, ProjectId, WorkClassCode, RegularBillRate, OvertimeBillRate, DoubletimeBillRate, TravelBillRate, Schedulable, CeilingCost, RegularHours, TravelHours, InSync) " +
                              $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, '{x.WorkClassCode}', {StrEx.ValueOrNull(x.RegularBillRate)}, {StrEx.ValueOrNull(x.OvertimeBillRate)}, {StrEx.ValueOrNull(x.DoubleTimeBillRate)}, {StrEx.ValueOrNull(x.TravelBillRate)}," +
                              $" '{x.Schedulable}', {StrEx.ValueOrNull(x.CeilingCost)}, {StrEx.ValueOrNull(x.RegularHours)}, {StrEx.ValueOrNull(x.TravelHours)}, 1)";
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
