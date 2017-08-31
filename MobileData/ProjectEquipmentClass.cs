using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.Equipment;

namespace MobileData
{
    public class ProjectEquipmentClass   // costing_equipment_class
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public int ProjectId;
        public string ClassCode;

        public bool Schedulable;
        public bool UseOverride;

        public decimal? BillRate;
        public EnumBillCycle BillCycle;

        static List<ProjectEquipmentClass> _list;

        public static List<ProjectEquipmentClass> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ProjectEquipmentClass>();
                    DataTable table = Common.ExecuteDataAdapter("select * from ProjectEquipmentClass");
                    table.Select().ToList().ForEach(r =>
                    {
                        _list.Add(new ProjectEquipmentClass
                        {
                            Id = r.Field<int>("Id"),
                            MatchId = r.Field<int>("MatchId"),
                            CompanyId = r.Field<int>("CompanyId"),
                            ProjectId = r.Field<int>("ProjectId"),
                            ClassCode = r.Field<string>("ClassCode"),
                            Schedulable = r.Field<bool>("Schedulable"),
                            UseOverride = r.Field<bool>("UseOverride"),
                            BillRate = r.Field<decimal?>("BillRate"),
                            BillCycle = (EnumBillCycle)r.Field<char>("BillCycle"),
                        });
                    });
                }
                return _list;
            }
        }

        public static List<ProjectEquipmentClass> ListForProject(int projectId)
        {
            return List.Where(x => x.ProjectId == projectId).ToList();
        }

        public static ProjectEquipmentClass GetProjectEquipmentClass(int id)
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
                HttpResponseMessage response = await client.GetAsync($"api/ProjectEquipmentClasses?companyId={Company.CurrentId}");
                if (response.IsSuccessStatusCode)
                {
                    List<ProjectEquipmentClass> list = await response.Content.ReadAsAsync<List<ProjectEquipmentClass>>();

                    string sql = $"delete ProjectEquipmentClass where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert ProjectEquipmentClass(MatchId, companyId, ProjectId, ClassCode, Schedulable, UseOverride, BillRate, BillCycle) " +
                          $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, '{x.ClassCode}', '{x.Schedulable}', '{x.UseOverride}', {x.BillRate}, '{(char)x.BillCycle}')";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
