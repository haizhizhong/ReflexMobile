using ReflexCommon;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.Equipment;

namespace MobileData
{
    public class EquipmentBillRate
    {
        public int Id;
        public int CompanyId;

        public string EqpNum;

        public EnumBillCycle BillCycle;
        public decimal BillRate;
        public bool IsDefault;

        static List<EquipmentBillRate> _list;

        static List<EquipmentBillRate> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from EquipmentBillRate");
                    _list = table.Select().Select(r => new EquipmentBillRate
                    {
                        Id = (int)r["Id"],
                        CompanyId = (int)r["CompanyId"],
                        EqpNum = (string)r["EqpNum"],
                        BillCycle = ConvertEx.CharToEnum<EnumBillCycle>(r["BillCycle"]),
                        BillRate = (decimal)r["BillRate"],
                        IsDefault = (bool)r["IsDefault"]
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<EquipmentBillRate> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<EquipmentBillRate> GetBillRatesForEquipment(string eqpNum)
        {
            return ListForCompany().Where(x => x.EqpNum == eqpNum).ToList();
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
