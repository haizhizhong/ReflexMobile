using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LevelThreeCode       //Level3_Codes
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int Level2Id;
        public string Code;
        public string Desc;

        public string DisplayName => $"{Code}\t{Desc}";

        static List<LevelThreeCode> _list;

        static List<LevelThreeCode> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Level3Code");
                    _list = table.Select().Select(r => new LevelThreeCode
                    {
                        Id = (int)r["ID"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        Level2Id = (int)r["Level2Id"],
                        Code = (string)r["Code"],
                        Desc = (string)r["Desc"]
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<LevelThreeCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<LevelThreeCode> SubList(int level2Id)
        {
            return ListForCompany().Where(x => x.Level2Id == level2Id).ToList();
        }

        public static List<LevelThreeCode> SubList(int level2Id, int projectId)
        {
            List<int> codeList = ProjectLevelCode.ListForProject(projectId).Where(x => x.Level3Id != null).Select(x => x.Level3Id.Value).Distinct().ToList();
            return ListForCompany().Where(x => x.Level2Id == level2Id && codeList.Contains(x.MatchId)).ToList();
        }

        public static LevelThreeCode GetLevelCode(int? matchId)
        {
            return ListForCompany().SingleOrDefault(x => x.MatchId == matchId);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
