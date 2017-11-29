using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class TimeCodeSync : ReceiveSync
    {
        protected override string TableName { get { return "TimeCode"; } }
        protected override string DisplayName { get { return "Time Code"; } }

        public TimeCodeSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                TimeCode.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/TimeCodes?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<TimeCode> list = await response.Content.ReadAsAsync<List<TimeCode>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert TimeCode(MatchId, companyId, [Desc], ValueType, BillingRateType, OvertimeId, DoubleTimeId, IncludedInWeekCalc, Component, ReportTypeColumn, InSync) " +
                              $"values({x.MatchId}, {x.CompanyId}, '{x.Desc}', '{x.ValueType}', '{x.BillingType}', {StrEx.ValueOrNull(x.OvertimeId)}, {StrEx.ValueOrNull(x.DoubleTimeId)}, '{x.IncludedInWeekCalc}', '{(char)x.Component}', {StrEx.StrOrNull(x.ReportTypeColumn)}, 1)";
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
