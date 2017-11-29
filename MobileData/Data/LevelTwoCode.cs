using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LevelTwoCode       //Level2_Codes
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int Level1Id;
        public string Code;
        public string Desc;

        public string DisplayName => $"{Code}\t{Desc}";

        static List<LevelTwoCode> _list;

        static List<LevelTwoCode> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Level2Code");
                    _list = table.Select().Select(r => new LevelTwoCode
                    {
                        Id = (int)r["ID"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        Level1Id = (int)r["Level1Id"],
                        Code = (string)r["Code"],
                        Desc = (string)r["Desc"]
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<LevelTwoCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<LevelTwoCode> SubList(int level1Id)
        {
            return ListForCompany().Where(x => x.Level1Id == level1Id).ToList();
        }

        public static List<LevelTwoCode> SubList(int level1Id, int projectId)
        {
            List<int> codeList = ProjectLevelCode.ListForProject(projectId).Where(x => x.Level2Id != null).Select(x => x.Level2Id.Value).Distinct().ToList();
            return ListForCompany().Where(x => x.Level1Id == level1Id && codeList.Contains(x.MatchId)).ToList();
        }

        public static LevelTwoCode GetLevelCode(int? matchId)
        {
            return ListForCompany().SingleOrDefault(x => x.MatchId == matchId);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
