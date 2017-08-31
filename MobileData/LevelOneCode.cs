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

        static List<LevelOneCode> _list;

        public static List<LevelOneCode> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<LevelOneCode>();

                    DataTable table = Common.ExecuteDataAdapter("select * from Level1Code");
                    table.Select().ToList().ForEach(r => _list.Add(new LevelOneCode
                    {
                        Id = (int)r["ID"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        Code = $"{r["Code"]}",
                        Desc = $"{r["Desc"]}",
                    }));
                }
                return _list;
            }
        }

        public static List<LevelOneCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static LevelOneCode GetCode(int id)
        {
            return List.SingleOrDefault(x => x.CompanyId == id && x.CompanyId == Company.CurrentId);
        }

        public static void Refresh()
        {
            _list = null;
        }

        public static void Sync(int companyId, List<LevelOneCode> list)
        {
            string sql = $"delete Level1Code where companyId = {companyId}";
            Common.ExecuteNonQuery(sql);

            list.ForEach(x =>
            {
                sql = $"insert Level1Code(MatchId, CompanyId, Code, [Desc]) " +
                $"values({x.MatchId}, {x.CompanyId}, '{x.Code}', '{x.Desc}')";
                Common.ExecuteNonQuery(sql);
            });

            Refresh();
        }

    }
}
