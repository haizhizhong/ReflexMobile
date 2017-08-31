using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class Project        //PY_ProjectLookUp (proj_header, PROJ_CONTACTS)
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public string Name;
        public int Code;
        public int CustomerId;
        public string SiteLocation;
        public DateTime? StartDate;
        public DateTime? EstCompletionDate;

        public string CustomerCode;
        public string CustomerName;
        public string CustomerAddress;
        public string POReference;
        public bool Billable;

        static List<Project> _list;

        public string GetNextLemNum()
        {
            string sql = $"select isnull(max(right(LemNum, 4)),0) from LemLogHeader where projectid = {MatchId}";
            int last = Convert.ToInt32(Common.ExecuteScalar(sql));

            return $"{Code,8}-{last + 1,4}".Replace(" ", "0");
        }

        public static List<Project> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<Project>();

                    DataTable table = Common.ExecuteDataAdapter("select * from Project");
                    table.Select().ToList().ForEach(r => _list.Add(new Project
                    {
                        Id = r.Field<int>("ID"),
                        MatchId = r.Field<int>("MatchId"),
                        CompanyId = r.Field<int>("CompanyId"),
                        Name = r.Field<string>("Name"),
                        Code = r.Field<int>("Code"),
                        CustomerId = r.Field<int>("CustomerId"),
                        CustomerCode = r.Field<string>("CustomerCode"),
                        CustomerName = r.Field<string>("CustomerName"),
                        CustomerAddress = r.Field<string>("CustomerAddress"),
                        SiteLocation = r.Field<string>("SiteLocation"),
                        StartDate = r.Field<DateTime?>("StartDate"),
                        EstCompletionDate = r.Field<DateTime?>("EstCompletionDate"),
                        Billable = r.Field<bool>("Billable")
                    }));
                }
                return _list;
            }
        }

        public static List<Project> AccessibleList()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId && LoginUser.CurrUser.ProjectList.Contains(x.MatchId)).ToList();
        }

        public static Project GetProject(int id)
        {
            return List.SingleOrDefault(x => x.MatchId == id && x.CompanyId == Company.CurrentId);
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

                HttpResponseMessage response = await client.GetAsync($"api/Projects?companyId={Company.CurrentId}");
                if (response.IsSuccessStatusCode)
                {
                    List<Project> list = await response.Content.ReadAsAsync<List<Project>>();

                    string sql = $"delete Project where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert Project(MatchId, CompanyId, Name, Code, CustomerId, CustomerCode, CustomerName, CustomerAddress, SiteLocation, StartDate, EstCompletionDate, Billable) " +
                          $"values({x.MatchId}, {x.CompanyId}, '{x.Name}', {x.Code}, {x.CustomerId}, '{x.CustomerCode}', '{x.CustomerName}', '{x.CustomerAddress}', '{x.SiteLocation}', {StringEx.ToStringOrNull(x.StartDate)}, {StringEx.ToStringOrNull(x.EstCompletionDate)}, '{x.Billable}')";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
