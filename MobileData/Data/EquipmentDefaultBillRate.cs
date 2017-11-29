using ReflexCommon;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.Equipment;

namespace MobileData
{
    public class EquipmentDefaultBillRate
    {
        public int Id;
        public int CompanyId;

        public EnumGroupType GroupType;
        public EnumBillCycle BillCycle;
        public decimal BillRate;
        public bool IsDefault;

        static List<EquipmentDefaultBillRate> _list;

        static List<EquipmentDefaultBillRate> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from EquipmentDefaultBillRate");
                    _list = table.Select().Select(r => new EquipmentDefaultBillRate
                    {
                        Id = (int)r["Id"],
                        CompanyId = (int)r["CompanyId"],
                        GroupType = ConvertEx.CharToEnum<EnumGroupType>(r["GroupType"]),
                        BillCycle = ConvertEx.CharToEnum<EnumBillCycle>(r["BillCycle"]),
                        BillRate = (decimal)r["BillRate"],
                        IsDefault = (bool)r["IsDefault"]
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<EquipmentDefaultBillRate> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<EquipmentDefaultBillRate> GetDefaultBillRates()
        {
            var type = Company.GetCurrCompany().EquipRateGroupType;
            return ListForCompany().Where(x => x.GroupType == type).ToList();
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
