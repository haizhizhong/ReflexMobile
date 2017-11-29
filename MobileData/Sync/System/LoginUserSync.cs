using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MobileData
{
    public class LoginUserSync : SystemSync
    {
        protected override string TableName { get { return "LoginUser"; } }
        protected override string DisplayName { get { return "Login User"; } }

        public override async System.Threading.Tasks.Task<SyncResult> Receive()
        {
            try
            {
                LoginUser.Refresh();

                using (HttpClient client = new HttpClient())
                {
                    client.Init();

                    HttpResponseMessage response = await client.GetAsync("api/LoginUsers");
                    if (response.IsSuccessStatusCode)
                    {
                        UpdateStatus(EnumTableSyncStatus.Receiving);

                        List<LoginUser> list = await response.Content.ReadAsAsync<List<LoginUser>>();
                        list.ForEach(x =>
                        {
                            string sql = $"insert LoginUser(MatchId, LoginName, CodeVersion, InSync) values({x.MatchId}, '{x.LoginName}', '1.0.0.0', 1); " +
                            $"Select CAST(SCOPE_IDENTITY() AS INT);";

                            int id = Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
                            x.AccessList.ForEach(r =>
                            {
                                sql = $"insert UserAccess( UserId, CompanyId, UserName, Department, InSync) values({id}, {r.CompanyId}, '{r.UserName}', '{r.Department}', 1)";
                                MobileCommon.ExecuteNonQuery(sql);
                            });

                            x.ProjectList.ForEach(c =>
                            {
                                sql = $"insert ProjectAccess( UserId, CompanyId, ProjectId, InSync) values({id}, {c.CompanyId}, {c.ProjectId}, 1)";
                                MobileCommon.ExecuteNonQuery(sql);
                            });
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
                return new SyncResult { Successful = false, Task = "LoginUser", Message = e.Message };
            }
        }

        public override void CommitReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"delete LoginUser where InSync<>1";
                MobileCommon.ExecuteNonQuery(sql);
                sql = $"update LoginUser set InSync=0";
                MobileCommon.ExecuteNonQuery(sql);

                sql = $"delete UserAccess where InSync<>1";
                MobileCommon.ExecuteNonQuery(sql);
                sql = $"update UserAccess set InSync=0";
                MobileCommon.ExecuteNonQuery(sql);

                sql = $"delete ProjectAccess where InSync<>1";
                MobileCommon.ExecuteNonQuery(sql);
                sql = $"update ProjectAccess set InSync=0";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);

                if (LoginUser.CurrUser != null)
                {
                    int? id = LoginUser.ValidUser(LoginUser.CurrUser.LoginName);
                    LoginUser.CurrUser = LoginUser.GetUser(id.Value);
                }
            }
        }

        public override void RollbackReceive()
        {
            if (new EnumTableSyncStatus[] { EnumTableSyncStatus.Receiving, EnumTableSyncStatus.CompleteReceive, EnumTableSyncStatus.ErrorInReceive }.Contains(SyncInfo.Status))
            {
                string sql = $"delete LoginUser where InSync=1";
                MobileCommon.ExecuteNonQuery(sql);

                sql = $"delete UserAccess where InSync=1";
                MobileCommon.ExecuteNonQuery(sql);

                sql = $"delete ProjectAccess where InSync=1";
                MobileCommon.ExecuteNonQuery(sql);

                UpdateStatus(EnumTableSyncStatus.ReadyToSync);
            }
        }
    }
}
