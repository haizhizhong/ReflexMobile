using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class EquipmentTemplate //   costing_equipment_class_equip
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public int EquipId;
        public int ProjectEquipClassId;
        public DateTime? StartDate;
        public DateTime? EndDate;

        static List<EquipmentTemplate> _list;

        public static List<EquipmentTemplate> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<EquipmentTemplate>();
                    DataTable table = Common.ExecuteDataAdapter("select * from EquipmentTemplate");
                    table.Select().ToList().ForEach(r => _list.Add(new EquipmentTemplate
                    {
                        Id = r.Field<int>("Id"),
                        MatchId = r.Field<int>("MatchId"),
                        CompanyId = r.Field<int>("CompanyId"),
                        EquipId = r.Field<int>("EquipId"),
                        ProjectEquipClassId = r.Field<int>("ProjectEquipClassId"),
                        StartDate = r.Field<DateTime?>("StartDate"),
                        EndDate = r.Field<DateTime?>("EndDate"),
                    }));
                }
                return _list;
            }
        }

        public static List<EquipmentTemplate> GetTemplate(int projectId, DateTime currDate)
        {
            var idList = ProjectEquipmentClass.ListForProject(projectId).Where(x => x.Schedulable == true).Select(x => x.Id);

            return List.Where(x => (x.StartDate == null || x.StartDate < currDate) && (x.EndDate == null || x.EndDate > currDate) && idList.Contains(x.ProjectEquipClassId)).ToList();
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
                HttpResponseMessage response = await client.GetAsync($"api/EquipmentTemplates?companyId={Company.CurrentId}");
                if (response.IsSuccessStatusCode)
                {
                    List<EquipmentTemplate> list = await response.Content.ReadAsAsync<List<EquipmentTemplate>>();

                    string sql = $"delete EquipmentTemplate where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert EquipmentTemplate(MatchId, CompanyId, EquipId, ProjectEquipClassId, StartDate, EndDate) " +
                          $"values({x.MatchId}, {x.CompanyId}, {x.EquipId}, {x.ProjectEquipClassId}, {StringEx.ToStringOrNull(x.StartDate)}, {StringEx.ToStringOrNull(x.EndDate)})";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
