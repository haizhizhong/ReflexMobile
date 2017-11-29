using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileData
{
    public class ProjectLevelCode
    {
        public int Id;
        public int ProjectId;
        public int CompanyId;

        public int? Level1Id;
        public int? Level2Id;
        public int? Level3Id;
        public int? Level4Id;

        static List<ProjectLevelCode> _list;

        static List<ProjectLevelCode> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from ProjectLevelCode");
                    _list = table.Select().Select(r => new ProjectLevelCode
                    {
                        Id = (int)r["ID"],
                        CompanyId = (int)r["CompanyId"],
                        ProjectId = (int)r["ProjectId"],
                        Level1Id = ConvertEx.ToNullable<int>(r["Level1Id"]),
                        Level2Id = ConvertEx.ToNullable<int>(r["Level2Id"]),
                        Level3Id = ConvertEx.ToNullable<int>(r["Level3Id"]),
                        Level4Id = ConvertEx.ToNullable<int>(r["Level4Id"]),
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<ProjectLevelCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<ProjectLevelCode> ListForProject(int projectId)
        {
            return ListForCompany().Where(x => x.ProjectId == projectId).ToList();
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
