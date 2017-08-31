using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MobileData
{
    public class ProjectAccess
    {
        public int ProjectId;
        public int UserId;

        //public static List<Company> GetUserAccess(int userId)
        //{
        //    List<Company> list = new List<Company>();

        //    string sql = $"select CompanyId from UserAccess where UserId={userId}";
        //    DataTable table = Common.ExecuteDataAdapter(sql);
        //    table.Select().ToList().ForEach(row => list.Add(Company.GetCompany((int)row["CompanyId"])));

        //    return list;
        //}

        public static async System.Threading.Tasks.Task Sync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Common.WebUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/ProjectAccess");
                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    List<ProjectAccess> list = JsonConvert.DeserializeObject<List<ProjectAccess>>(jsonAsString);

                    string sql = $"delete ProjectAccess";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert ProjectAccess( UserId, ProjectId) values({x.UserId}, {x.ProjectId})";
                        Common.ExecuteNonQuery(sql);
                    });
                }
            }
        }
    }
}
