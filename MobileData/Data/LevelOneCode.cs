using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LevelOneCode       //Level1_Codes
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public string Code;
        public string Desc;

        public string DisplayName => $"{Code}\t{Desc}";

        static List<LevelOneCode> _list;

        static List<LevelOneCode> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Level1Code");
                    _list = table.Select().Select(r => new LevelOneCode
                    {
                        Id = (int)r["ID"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        Code = (string)r["Code"],
                        Desc = (string)r["Desc"]
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<LevelOneCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<LevelOneCode> ListForProject(int projectId)
        {
            List<int> codeList = ProjectLevelCode.ListForProject(projectId).Where(x => x.Level1Id != null).Select(x => x.Level1Id.Value).Distinct().ToList();
            return ListForCompany().Where(x => codeList.Contains(x.MatchId)).ToList();
        }

        public static LevelOneCode GetLevelCode(int? matchId)
        {
            return ListForCompany().SingleOrDefault(x => x.MatchId == matchId);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
