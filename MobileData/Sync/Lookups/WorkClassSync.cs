using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using static MobileData.TimeCode;

namespace MobileData
{
    public class WorkClassSync : ReceiveSync
    {
        protected override string TableName { get { return "WorkClass"; } }
        protected override string DisplayName { get { return "Work Class"; } }

        public WorkClassSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/WorkClasses?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<WorkClass> list = await response.Content.ReadAsAsync<List<WorkClass>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert WorkClass(MatchId, companyId, Code, [Desc], RegularBillRate, OvertimeBillRate, DoubletimeBillRate, TravelBillRate, InSync) " +
                              $"values({x.MatchId}, {x.CompanyId}, '{x.Code}', '{x.Desc}', {StrEx.ValueOrNull(x.RegularBillRate)}, {StrEx.ValueOrNull(x.OvertimeBillRate)}, {StrEx.ValueOrNull(x.DoubleTimeBillRate)}, {StrEx.ValueOrNull(x.TravelBillRate)}, 1)";
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
