using ReflexCommon;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class Equipment      //
    {
        public enum EnumBillCycle
        {
            Yearly = 'Y',
            Monthly = 'M',
            Weekly = 'W',
            Daily = 'D',
            Hourly = 'H',
            Unknown = 'U'
        }

        public enum EnumGroupType
        {
            Class = 'L',
            Category = 'C'
        }

        public enum EnumOwnerType
        {
            Owned = 'O',
            Leased = 'L',
            Consigned = 'C',
            Rentable = 'R',
            Employee = 'E',
            Unknown = 'U'
        }

        public int Id;
        public string EqpNum;
        public int CompanyId;

        public string AssetCode;
        public string Desc;
        public string ClassCode;
        public string CategoryCode;
        public EnumOwnerType OwnerType;
        public bool UseOveride;

        public string DisplayName => $"{Desc}";

        public EnumBillCycle GetDefaultBillCycle(int projectId)
        {
            ProjectEquipmentClass projClass = ProjectEquipmentClass.GetProjectEquipmentClass(projectId, ClassCode);
            return projClass.BillCycle;
        }

        public List<EquipmentBillRate> GetBillRateList(int projectId)
        {
            List<EquipmentBillRate> list;
            ProjectEquipmentClass projClass = ProjectEquipmentClass.GetProjectEquipmentClass(projectId, ClassCode);
            if (!UseOveride && (projClass?.UseOverride ?? false) ==false)
            {
                list = EquipmentGroupBillRate.GetBillRatesForGroup(projectId, ClassCode, CategoryCode).Select(r => new EquipmentBillRate { BillCycle = r.BillCycle, BillRate = r.BillRate, IsDefault = r.IsDefault }).ToList();
                if (list.Any())     //Link to project * group(class or category) 
                    return list;

                list = EquipmentGroupBillRate.GetBillRatesForGroup(null, ClassCode, CategoryCode).Select(r => new EquipmentBillRate { BillCycle = r.BillCycle, BillRate = r.BillRate, IsDefault = r.IsDefault }).ToList();
                if (list.Any())     // Link to Group (class or category)
                    return list;
            }

            list = EquipmentBillRate.GetBillRatesForEquipment(EqpNum);          // link to Equip 
            if (list.Any())
                return list;

            return EquipmentDefaultBillRate.GetDefaultBillRates().Select(r => new EquipmentBillRate { BillCycle = r.BillCycle, BillRate = r.BillRate, IsDefault = r.IsDefault }).ToList(); // Link to Default
        }

        static List<Equipment> _list;

        private static List<Equipment> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Equipment");
                    _list = table.Select().Select(r => new Equipment
                    {
                        Id = (int)r["Id"],
                        EqpNum = (string)r["EqpNum"],
                        CompanyId = (int)r["CompanyId"],
                        AssetCode = (string)r["AssetCode"],
                        Desc = (string)r["Desc"],
                        ClassCode = (string)r["ClassCode"],
                        CategoryCode = (string)r["CategoryCode"],
                        OwnerType = ConvertEx.CharToEnum<EnumOwnerType>(r["OwnerType"])
                    }).ToList();

                }
                return _list;
            }
        }

        public static List<Equipment> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static Equipment GetEquipment(string eqpNum)
        {
            return ListForCompany().SingleOrDefault(x => x.EqpNum == eqpNum);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
