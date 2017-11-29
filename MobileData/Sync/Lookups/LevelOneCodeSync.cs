using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MobileData
{
    public class LevelOneCodeSync : ReceiveSync
    {
        protected override string TableName { get { return "Level1Code"; } }
        protected override string DisplayName { get { return "Level1 Code"; } }

        public LevelOneCodeSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                LevelOneCode.Refresh();
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    HttpResponseMessage response = await client.GetAsync($"api/LevelOneCodes?companyId={CompanyId}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<LevelOneCode> list = await response.Content.ReadAsAsync<List<LevelOneCode>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert Level1Code(MatchId, CompanyId, Code, [Desc], InSync) " +
                            $"values({x.MatchId}, {x.CompanyId}, '{x.Code}', '{x.Desc}',1 )";
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
