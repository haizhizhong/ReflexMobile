using ReflexCommon;
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

        static List<ProjectEquipmentClass> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from ProjectEquipmentClass");
                    _list = table.Select().Select(r => new ProjectEquipmentClass
                    {
                        Id = (int)r["Id"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        ProjectId = (int)r["ProjectId"],
                        ClassCode = (string)r["ClassCode"],
                        Schedulable = (bool)r["Schedulable"],
                        UseOverride = (bool)r["UseOverride"],
                        BillRate = ConvertEx.ToNullable<decimal>(r["BillRate"]),
                        BillCycle = ConvertEx.CharToEnum<EnumBillCycle>(r["BillCycle"]),
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<ProjectEquipmentClass> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<ProjectEquipmentClass> ListForProject(int projectId)
        {
            return ListForCompany().Where(x => x.ProjectId == projectId).ToList();
        }

        public static ProjectEquipmentClass GetProjectEquipmentClass(int projectId, string classCode)
        {
            return ListForProject(projectId).SingleOrDefault(x => x.ClassCode == classCode);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
