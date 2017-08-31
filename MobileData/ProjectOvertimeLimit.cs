using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class ProjectOvertimeLimit // ot_limit
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public int ProjectId;
        public string Code;
        public string Desc;

        public decimal? DailyLimit;
        public decimal? DailyDoubleLimit;
        public decimal? WeeklyLimit;
        public decimal? WeeklyDoubleLimit;

        static List<ProjectOvertimeLimit> _list;

        public static List<ProjectOvertimeLimit> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ProjectOvertimeLimit>();
                    DataTable table = Common.ExecuteDataAdapter("select * from ProjectOvertimeLimit");
                    table.Select().ToList().ForEach(r =>
                    {
                        _list.Add(new ProjectOvertimeLimit
                        {
                            Id = r.Field<int>("Id"),
                            MatchId = r.Field<int>("MatchId"),
                            CompanyId = r.Field<int>("CompanyId"),
                            ProjectId = r.Field<int>("ProjectId"),
                            Code = r.Field<string>("Code"),
                            Desc = r.Field<string>("Desc"),
                            DailyLimit = r.Field<decimal?>("DailyLimit"),
                            DailyDoubleLimit = r.Field<decimal?>("DailyDoubleLimit"),
                            WeeklyLimit = r.Field<decimal?>("WeeklyLimit"),
                            WeeklyDoubleLimit = r.Field<decimal?>("WeeklyDoubleLimit"),
                        });
                    });
                }
                return _list;
            }
        }

        public static List<ProjectOvertimeLimit> ListForProject(int projectId)
        {
            return List.Where(x => x.ProjectId == projectId).ToList();
        }

        public static ProjectOvertimeLimit GetProjectOvertimeLimit(int id)
        {
            return List.SingleOrDefault(x => x.MatchId == id);
        }

        public static decimal GetOvertime(int projectId, decimal dayHours, decimal weekHours)
        {
            List<ProjectOvertimeLimit> limit = ListForProject(projectId);
            decimal dayLimit = limit.Min(x => x.DailyLimit ?? decimal.MaxValue);
            decimal weekLimit = limit.Min(x => x.WeeklyLimit ?? decimal.MaxValue);

            return Math.Max(Math.Max(dayHours - dayLimit, 0), Math.Max(weekHours - weekLimit, 0));
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
                HttpResponseMessage response = await client.GetAsync($"api/ProjectOvertimeLimits?companyId={Company.CurrentId}");
                if (response.IsSuccessStatusCode)
                {
                    List<ProjectOvertimeLimit> list = await response.Content.ReadAsAsync<List<ProjectOvertimeLimit>>();

                    string sql = $"delete ProjectOvertimeLimit where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert ProjectOvertimeLimit(MatchId, companyId, ProjectId, Code, [Desc], DailyLimit, DailyDoubleLimit, WeeklyLimit, WeeklyDoubleLimit) " +
                          $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, '{x.Code}', '{x.Desc}', {StringEx.ToValueOrNull(x.DailyLimit)}, {StringEx.ToValueOrNull(x.DailyDoubleLimit)}, " +
                          $"{StringEx.ToValueOrNull(x.WeeklyLimit)}, {StringEx.ToValueOrNull(x.WeeklyDoubleLimit)})";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
