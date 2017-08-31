using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MobileData
{
    public class Company      //Company
    {
        public int Id;
        public int MatchId;
        public string CompanyName;
        public string Server;
        public string DataBase;
        public bool IsDefault;
        public DateTime LastSyncTime;

        public DayOfWeek WeekStart;   //hr_cntl.week_start
        public int LemAvailableDays;

        public static int CurrentId { get; set; }

        static List<Company> _list;

        public static List<Company> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<Company>();
                    DataTable table = Common.ExecuteDataAdapter("select * from Company");
                    table.Select().ToList().ForEach(r => _list.Add(
                        new Company
                        {
                            Id = (int)r["Id"],
                            MatchId = (int)r["MatchId"],
                            CompanyName = $"{r["CompanyName"]}",
                            Server = $"{r["Server"]}",
                            DataBase = $"{r["DataBase"]}",
                            IsDefault = (bool)r["IsDefault"],
                            LastSyncTime = (DateTime)r["LastSyncTime"]
                        }));
                }
                return _list;
            }
        }

        public static Company GetCompany(int id)
        {
            return List.SingleOrDefault(x => x.MatchId == id);
        }

        public static void Refresh()
        {
            _list = null;
        }

        public static async System.Threading.Tasks.Task Sync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Common.WebUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Companies");
                if (response.IsSuccessStatusCode)
                {
                    List<Company> list = await response.Content.ReadAsAsync<List<Company>>();

                    string sql = $"delete Company";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert Company(MatchId, CompanyName, [Server], [Database], IsDefault, LastSyncTime) " +
                          $"values({x.MatchId}, '{x.CompanyName}', '{x.Server}', '{x.DataBase}', '{x.IsDefault}', getdate())";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
