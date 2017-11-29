using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class EquipmentCategory   // fa_cat
    {
        public int Id;
        public int CompanyId;

        public string Code;
        public string Desc;

        static List<EquipmentCategory> _list;

        static List<EquipmentCategory> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from EquipmentCategory");
                    _list = table.Select().Select(r => new EquipmentCategory
                    {
                        Id = (int)r["Id"],
                        CompanyId = (int)r["CompanyId"],
                        Code = (string)r["Code"],
                        Desc = (string)r["Desc"],
                    }).ToList();
                }

                return _list;
            }
        }

        public static List<EquipmentCategory> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static EquipmentCategory GetEquipmentCategory(string code)
        {
            return ListForCompany().SingleOrDefault(x => x.Code == code);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
