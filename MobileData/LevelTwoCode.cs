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

        static List<LevelTwoCode> _list;

        public static List<LevelTwoCode> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<LevelTwoCode>();

                    DataTable table = Common.ExecuteDataAdapter("select * from Level2Code");
                    table.Select().ToList().ForEach(r => _list.Add(
                        new LevelTwoCode
                        {
                            Id = (int)r["ID"],
                            MatchId = (int)r["MatchId"],
                            CompanyId = (int)r["CompanyId"],
                            Level1Id = (int)r["Level1Id"],
                            Code = $"{r["Code"]}",
                            Desc = $"{r["Desc"]}",
                        }));
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
            return List.Where(x => x.CompanyId == Company.CurrentId && x.Level1Id == level1Id).ToList();
        }

        public static LevelTwoCode GetCode(int id)
        {
            return List.SingleOrDefault(x => x.MatchId == id && x.CompanyId == Company.CurrentId);
        }

        public static void Refresh()
        {
            _list = null;
        }

        public static void Sync(int companyId, List<LevelTwoCode> list)
        {
            string sql = $"delete Level2Code where companyId = {companyId}";
            Common.ExecuteNonQuery(sql);

            list.ForEach(x =>
            {
                sql = $"insert Level1Code(MatchId, companyId, Level1Id, Code, [Desc]) " +
                $"values({x.MatchId}, {x.CompanyId}, {x.Level1Id}, '{x.Code}', '{x.Desc}')";
                Common.ExecuteNonQuery(sql);
            });

            Refresh();
        }


    }
}
