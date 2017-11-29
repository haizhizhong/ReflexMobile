using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class LevelFourCodeSync : ReceiveSync
    {
        protected override string TableName { get { return "Level4Code"; } }
        protected override string DisplayName { get { return "Level4 Code"; } }

        public LevelFourCodeSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                LevelFourCode.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/LevelFourCodes?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<LevelFourCode> list = await response.Content.ReadAsAsync<List<LevelFourCode>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Level4Code(MatchId, companyId, Level3Id, Code, [Desc], InSync) " +
                            $"values({x.MatchId}, {x.CompanyId}, {x.Level3Id}, '{x.Code}', '{x.Desc}', 1)";
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
