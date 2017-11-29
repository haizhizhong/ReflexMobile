using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class LevelThreeCodeSync : ReceiveSync
    {
        protected override string TableName { get { return "Level3Code"; } }
        protected override string DisplayName { get { return "Level3 Code"; } }

        public LevelThreeCodeSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                LevelThreeCode.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/LevelThreeCodes?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<LevelThreeCode> list = await response.Content.ReadAsAsync<List<LevelThreeCode>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Level3Code(MatchId, companyId, Level2Id, Code, [Desc], InSync) " +
                            $"values({x.MatchId}, {x.CompanyId}, {x.Level2Id}, '{x.Code}', '{x.Desc}', 1)";
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
