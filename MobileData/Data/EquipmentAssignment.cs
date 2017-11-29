using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class EquipmentAssignment      //equip_assign
    {
        public int Id;
        public int CompanyId;

        public string EqpNum;
        public int EmpNum;
        public DateTime? AssignedDate;
        public DateTime? ReleasedDate;

        public string EarnGroup;
        public string EarnCode;

        static List<EquipmentAssignment> _list;

        static List<EquipmentAssignment> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from EquipmentAssignment");
                    _list = table.Select().Select(r => new EquipmentAssignment
                    {
                        Id = (int)r["Id"],
                        CompanyId = (int)r["CompanyId"],
                        EqpNum = (string)r["EqpNum"],
                        EmpNum = (int)r["EmpNum"],
                        AssignedDate = ConvertEx.ToNullable<DateTime>(r["AssignedDate"]),
                        ReleasedDate = ConvertEx.ToNullable<DateTime>(r["ReleasedDate"]),
                        EarnGroup = (string)r["EarnGroup"],
                        EarnCode = (string)r["EarnCode"],
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<EquipmentAssignment> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static Employee GetEmployee(string eqpNum, DateTime date)
        {
            var ea = ListForCompany().FirstOrDefault(x => x.EqpNum == eqpNum && (x.AssignedDate == null || x.AssignedDate < date) && (x.ReleasedDate == null || x.ReleasedDate > date));
            return Employee.GetEmployee(ea?.EmpNum ?? -1);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
