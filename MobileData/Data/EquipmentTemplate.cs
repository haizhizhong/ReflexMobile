using ReflexCommon;
using System;
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
        public int ProjectId;

        public string EqpNum;
        public string EquipClassCode;
        public DateTime? StartDate;
        public DateTime? EndDate;

        static List<EquipmentTemplate> _list;

        static List<EquipmentTemplate> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from EquipmentTemplate");
                    _list = table.Select().Select(r => new EquipmentTemplate
                    {
                        Id = (int)r["Id"],
                        MatchId = (int)r["MatchId"],
                        ProjectId = (int)r["ProjectId"],
                        CompanyId = (int)r["CompanyId"],
                        EqpNum = (string)r["EqpNum"],
                        EquipClassCode = (string)r["EquipClassCode"],
                        StartDate = ConvertEx.ToNullable<DateTime>(r["StartDate"]),
                        EndDate = ConvertEx.ToNullable<DateTime>(r["EndDate"]),
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<EquipmentTemplate> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<EquipmentTemplate> ListForProject(int projectId)
        {
            return ListForCompany().Where(x => x.ProjectId == projectId).ToList();
        }

        public static List<EquipmentTemplate> GetTemplate(int projectId, DateTime currDate)
        {
            var codeList = ProjectEquipmentClass.ListForProject(projectId).Where(x => x.Schedulable == true).Select(x => x.ClassCode);
            return ListForProject(projectId).Where(x => (x.StartDate == null || x.StartDate < currDate) && (x.EndDate == null || x.EndDate > currDate) && codeList.Contains(x.EquipClassCode)).ToList();
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
