using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LabourTemplate     // costing_work_class_emp
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int EmpNum;
        public int ProjectWorkClassId;
        public DateTime? StartDate;
        public DateTime? EndDate;

        static List<LabourTemplate> _list;

        public static List<LabourTemplate> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<LabourTemplate>();
                    DataTable table = Common.ExecuteDataAdapter("select * from LabourTemplate");
                    table.Select().ToList().ForEach(r => _list.Add(new LabourTemplate
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        MatchId = Convert.ToInt32(r["MatchId"]),
                        CompanyId = Convert.ToInt32(r["CompanyId"]),
                        EmpNum = Convert.ToInt32(r["EmpNum"]),
                        ProjectWorkClassId = Convert.ToInt32(r["ProjectWorkClassId"]),
                        StartDate = r["StartDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["StartDate"]),
                        EndDate = r["EndDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["EndDate"]),
                    }));
                }
                return _list;
            }
        }

        public static List<LabourTemplate> GetTemplate(int projectId, DateTime currDate)
        {
            var idList = ProjectWorkClass.ListForProject(projectId).Where( x=> x.Schedulable==true).Select( x=> x.Id);

            return List.Where(x => (x.StartDate == null || x.StartDate < currDate) && (x.EndDate == null || x.EndDate > currDate) && idList.Contains(x.ProjectWorkClassId)).ToList();
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
                HttpResponseMessage response = await client.GetAsync($"api/LabourTemplates?companyId={Company.CurrentId}");

                if (response.IsSuccessStatusCode)
                {
                    List<LabourTemplate> list = await response.Content.ReadAsAsync<List<LabourTemplate>>();

                    string sql = $"delete LabourTemplate where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert LabourTemplate(MatchId, CompanyId, EmpNum, ProjectWorkClassId, StartDate, EndDate)  " +
                          $"values({x.MatchId}, {x.CompanyId}, {x.EmpNum}, {x.ProjectWorkClassId}, {StringEx.ToStringOrNull(x.StartDate)}, {StringEx.ToStringOrNull(x.EndDate)})";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
