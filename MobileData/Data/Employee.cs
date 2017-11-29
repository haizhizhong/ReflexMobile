using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class Employee //employee
    {
        public int Id;
        public int EmpNum;
        public int CompanyId;

        public string FirstName;
        public string LastName;
        public string WorkClassCode;  //wc_code
        public string OvertimeCode;   //ol_code

        public string DisplayName => $"{FirstName} {LastName}";

        static List<Employee> _list;

        private static List<Employee> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from Employee");
                    _list = table.Select().Select(r => new Employee
                    {
                        Id = (int)r["Id"],
                        EmpNum = (int)r["EmpNum"],
                        CompanyId = (int)r["CompanyId"],
                        FirstName = (string)r["FirstName"],
                        LastName = (string)r["LastName"],
                        WorkClassCode = (string)r["WorkClassCode"],
                        OvertimeCode = (string)r["OvertimeCode"],
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<Employee> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static Employee GetEmployee(int empNum)
        {
            return ListForCompany().SingleOrDefault(x => x.EmpNum == empNum && x.CompanyId == Company.CurrentId);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
