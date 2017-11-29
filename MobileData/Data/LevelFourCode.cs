using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LevelFourCode       //Level4_Codes
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int Level3Id;
        public string Code;
        public string Desc;

        public string DisplayName => $"{Code}\t{Desc}";

        static List<LevelFourCode> _list;

        static List<LevelFourCode> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Level4Code");
                    _list = table.Select().Select(r => new LevelFourCode
                    {
                        Id = (int)r["ID"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        Level3Id = (int)r["Level3Id"],
                        Code = (string)r["Code"],
                        Desc = (string)r["Desc"]
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<LevelFourCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<LevelFourCode> SubList(int level3Id, int projectId)
        {
            List<int> codeList = ProjectLevelCode.ListForProject(projectId).Where(x => x.Level3Id != null).Select(x => x.Level3Id.Value).Distinct().ToList();
            return ListForCompany().Where(x => x.Level3Id == level3Id && codeList.Contains(x.MatchId)).ToList();
        }

        public static LevelFourCode GetLevelCode(int? matchId)
        {
            return ListForCompany().SingleOrDefault(x => x.MatchId == matchId);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
