using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MobileData
{
    public class LoginUser      //Contact
    {
        public int Id;
        public int MatchId;
        public string UserName;
        public string Password;

        public List<int> CompanyList;
        public List<int> ProjectList;

        public static LoginUser CurrUser { get; set; }

        public static LoginUser GetUser(int userId)
        {
            string sql = $"select* from LoginUser where id ={userId}";
            DataTable table = Common.ExecuteDataAdapter(sql);
            LoginUser user = new LoginUser
            {
                Id = (int)table.Rows[0]["Id"],
                MatchId = (int)table.Rows[0]["MatchId"],
                UserName = (string)table.Rows[0]["UserName"],
                Password = (string)table.Rows[0]["Password"],
                CompanyList = new List<int>(),
                ProjectList = new List<int>()
            };

            sql = $"select CompanyId from UserAccess where UserId ={user.Id}";
            table = Common.ExecuteDataAdapter(sql);
            table.Select().ToList().ForEach(r => user.CompanyList.Add((int)r["CompanyId"]));

            sql = $"select ProjectId from ProjectAccess where UserId ={user.Id}";
            table = Common.ExecuteDataAdapter(sql);
            table.Select().ToList().ForEach(r => user.ProjectList.Add((int)r["ProjectId"]));

            return user;
        }

        public static int? ValidUser(string user, string password)
        {
            string sql = $"select id from LoginUser where Username='{user}' and Password='{password}'";
            return (int?)Common.ExecuteScalar(sql);
        }

        public static List<Company> GetUserAccess(int userId)
        {
            List<Company> list = new List<Company>();

            string sql = $"select CompanyId from UserAccess where UserId={userId}";
            DataTable table = Common.ExecuteDataAdapter(sql);
            table.Select().ToList().ForEach(row => list.Add(Company.GetCompany((int)row["CompanyId"])));

            return list;
        }

        public static async System.Threading.Tasks.Task Sync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Common.WebUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/LoginUsers");
                if (response.IsSuccessStatusCode)
                {
                    List<LoginUser> list = await response.Content.ReadAsAsync<List<LoginUser>>();

                    string sql = $"delete LoginUser";
                    Common.ExecuteNonQuery(sql);

                    sql = $"delete UserAccess";
                    Common.ExecuteNonQuery(sql);

                    sql = $"delete ProjectAccess";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert LoginUser(MatchId, UserName, Password) values({x.MatchId}, '{x.UserName}', '{x.Password}'); " +
                        $"Select CAST(SCOPE_IDENTITY() AS INT);";

                        int id = Convert.ToInt32( Common.ExecuteScalar(sql));
                        x.CompanyList.ForEach(c =>
                        {
                               sql = $"insert UserAccess( UserId, CompanyId) values({id}, {c})";
                               Common.ExecuteNonQuery(sql);
                        });

                        x.ProjectList.ForEach(c =>
                        {
                            sql = $"insert ProjectAccess( UserId, ProjectId) values({id}, {c})";
                            Common.ExecuteNonQuery(sql);
                        });
                    });
                }
            }
        }
    }
}
