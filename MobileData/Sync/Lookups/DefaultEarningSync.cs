﻿using System;
using System.Net.Http;
using System.Collections.Generic;
using ReflexCommon;
using System.Web;

namespace MobileData
{
    public class DefaultEarningSync : ReceiveSync
    {
        protected override string TableName { get { return "DefaultEarning"; } }
        protected override string DisplayName { get { return "Default Earning"; } }

        public DefaultEarningSync(int companyId) : base(companyId)
        {
        }

        public override async System.Threading.Tasks.Task<SyncResult> Receive(Guid token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Init(token);

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["contactId"] = LoginUser.CurrUser.MatchId.ToString();
                    query["companyId"] = CompanyId.ToString();
                    HttpResponseMessage response = await client.GetAsync($"api/DefaultEarning?{query.ToString()}");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<DefaultEarning> list = await response.Content.ReadAsAsync<List<DefaultEarning>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert DefaultEarning(CompanyId, ProjectId, Level1Id, Level2Id, Level3Id, Level4Id, EarningType, InSync) " +
                              $"values({x.CompanyId}, {x.ProjectId}, {StrEx.ValueOrNull(x.Level1Id)}, {StrEx.ValueOrNull(x.Level2Id)}, {StrEx.ValueOrNull(x.Level3Id)}, {StrEx.ValueOrNull(x.Level4Id)}, '{(char)x.EarningType}', 1)";
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
