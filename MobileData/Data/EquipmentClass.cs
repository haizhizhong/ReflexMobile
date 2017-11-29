using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class EquipmentClass   // fa_class
    {
        public int Id;
        public int CompanyId;

        public string Code;
        public string Desc;

        public string DisplayName => $"{Desc}";

        static List<EquipmentClass> _list;

        static List<EquipmentClass> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from EquipmentClass");
                    _list = table.Select().Select(r => new EquipmentClass
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

        public static List<EquipmentClass> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static EquipmentClass GetEquipmentClass(string code)
        {
            return ListForCompany().SingleOrDefault(x => x.Code == code);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
