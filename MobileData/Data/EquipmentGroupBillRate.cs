using ReflexCommon;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.Equipment;

namespace MobileData
{
    public class EquipmentGroupBillRate
    {
        public int Id;
        public int CompanyId;
        public int? ProjectId;       // null for common

        public string GroupCode;     // class or category
        public EnumGroupType GroupType;     

        public EnumBillCycle BillCycle;
        public decimal BillRate;
        public bool IsDefault;

        static List<EquipmentGroupBillRate> _list;

        static List<EquipmentGroupBillRate> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from EquipmentGroupBillRate");
                    _list = table.Select().Select(r => new EquipmentGroupBillRate
                    {
                        Id = (int)r["Id"],
                        CompanyId = (int)r["CompanyId"],
                        ProjectId = ConvertEx.ToNullable<int>(r["ProjectId"]),
                        GroupCode = (string)r["GroupCode"],
                        GroupType = ConvertEx.CharToEnum<EnumGroupType>(r["GroupType"]),
                        BillCycle = ConvertEx.CharToEnum<EnumBillCycle>(r["BillCycle"]),
                        BillRate = (decimal)r["BillRate"],
                        IsDefault = (bool)r["IsDefault"]
                    }).ToList();
                }

                return _list;
            }
        }

        public static List<EquipmentGroupBillRate> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<EquipmentGroupBillRate> GetBillRatesForGroup(int? projectId, string classCode, string cateCode)
        {
            var type = Company.GetCurrCompany().EquipRateGroupType;
            var code = (type == EnumGroupType.Class) ? classCode : cateCode;

            return ListForCompany().Where(x => x.ProjectId == projectId && x.GroupType==type && x.GroupCode == code).ToList();
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
