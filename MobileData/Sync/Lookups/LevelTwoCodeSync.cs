using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class LevelTwoCodeSync : ReceiveSync
    {
        protected override string TableName { get { return "Level2Code"; } }
        protected override string DisplayName { get { return "Level2 Code"; } }

        public LevelTwoCodeSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                LevelTwoCode.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/LevelTwoCodes?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<LevelTwoCode> list = await response.Content.ReadAsAsync<List<LevelTwoCode>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Level2Code(MatchId, companyId, Level1Id, Code, [Desc], InSync) " +
                            $"values({x.MatchId}, {x.CompanyId}, {x.Level1Id}, '{x.Code}', '{x.Desc}', 1)";
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
