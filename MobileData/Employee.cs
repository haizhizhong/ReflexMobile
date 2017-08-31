using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MobileData
{
    public class Employee       //employee
    {
        public int Id;
        public int EmpNum;
        public int CompanyId;

        public string FirstName;
        public string LastName;
        public string WorkClassCode;  //wc_code

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public int GetWorkClassId()
        {
            return WorkClass.ListForCompany().SingleOrDefault(x => x.Code == WorkClassCode)?.Id ?? -1;
        }

        static List<Employee> _list;

        public static List<Employee> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<Employee>();
                    DataTable table = Common.ExecuteDataAdapter("select * from Employee");
                    table.Select().ToList().ForEach(r => _list.Add(new Employee
                    {
                        Id = (int)r["Id"],
                        EmpNum = (int)r["EmpNum"],
                        CompanyId = (int)r["CompanyId"],
                        FirstName = $"{r["FirstName"]}",
                        LastName = $"{r["LastName"]}",
                        WorkClassCode = $"{r["WorkClassCode"]}"
                    }));
                }
                return _list;
            }
        }

        public static List<Employee> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static Employee GetEmployee(int empNum)
        {
            return List.SingleOrDefault(x => x.EmpNum == empNum && x.CompanyId == Company.CurrentId);
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

                HttpResponseMessage response = await client.GetAsync($"api/Employees?companyId={Company.CurrentId}");
                if (response.IsSuccessStatusCode)
                {
                    List<Employee> list = await response.Content.ReadAsAsync<List<Employee>>();

                    string sql = $"delete Employee where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert Employee(EmpNum, CompanyId, FirstName, LastName, WorkClassCode) " +
                          $"values({x.EmpNum}, {x.CompanyId}, '{x.FirstName.Replace("'", "''")}', '{x.LastName.Replace("'", "''")}', '{x.WorkClassCode}')";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
