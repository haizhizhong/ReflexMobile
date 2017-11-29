using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;

namespace MobileData
{
    public class OvertimeLimitSync : ReceiveSync
    {
        protected override string TableName { get { return "OvertimeLimit"; } }
        protected override string DisplayName { get { return "Overtime Limit"; } }

        public OvertimeLimitSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                OvertimeLimit.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/OvertimeLimits?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<OvertimeLimit> list = await response.Content.ReadAsAsync<List<OvertimeLimit>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert OvertimeLimit(MatchId, companyId, ProjectId, Code, [Desc], DailyLimit, DailyDoubleLimit, WeeklyLimit, WeeklyDoubleLimit, InSync) " +
                              $"values({x.MatchId}, {x.CompanyId}, {StrEx.ValueOrNull(x.ProjectId)}, '{x.Code}', '{x.Desc}', {StrEx.ValueOrNull(x.DailyLimit)}, {StrEx.ValueOrNull(x.DailyDoubleLimit)}, " +
                              $"{StrEx.ValueOrNull(x.WeeklyLimit)}, {StrEx.ValueOrNull(x.WeeklyDoubleLimit)}, 1)";
                            MobileCommon.ExecuteNonQuery(sql);
                        });

                        UpdateStatus( EnumTableSyncStatus.CompleteReceive);
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
