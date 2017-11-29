using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class Supplier // Supplier_master
    {
        public int Id;
        public int CompanyId;

        public string SupplierCode;
        public string SupplierName;

        static List<Supplier> _list;

        private static List<Supplier> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Supplier");
                    _list = table.Select().Select(r => new Supplier
                    {
                        Id = (int)r["Id"],
                        SupplierCode = (string)r["SupplierCode"],
                        CompanyId = (int)r["CompanyId"],
                        SupplierName = (string)r["SupplierName"],
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<Supplier> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static Supplier GetSupplier(string code)
        {
            return ListForCompany().SingleOrDefault(x => x.SupplierCode == code);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
