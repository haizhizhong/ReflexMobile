using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class OvertimeLimit // ot_limit
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public int? ProjectId;
        public string Code;
        public string Desc;

        public decimal? DailyLimit;
        public decimal? DailyDoubleLimit;
        public decimal? WeeklyLimit;
        public decimal? WeeklyDoubleLimit;

        static List<OvertimeLimit> _list;

        static List<OvertimeLimit> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from OvertimeLimit");
                    _list = table.Select().Select(r => new OvertimeLimit
                    {
                        Id = (int)r["Id"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        ProjectId = ConvertEx.ToNullable<int>(r["ProjectId"]),
                        Code = (string)r["Code"],
                        Desc = (string)r["Desc"],
                        DailyLimit = ConvertEx.ToNullable<decimal>(r["DailyLimit"]),
                        DailyDoubleLimit = ConvertEx.ToNullable<decimal>(r["DailyDoubleLimit"]),
                        WeeklyLimit = ConvertEx.ToNullable<decimal>(r["WeeklyLimit"]),
                        WeeklyDoubleLimit = ConvertEx.ToNullable<decimal>(r["WeeklyDoubleLimit"])
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<OvertimeLimit> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }


        public static List<OvertimeLimit> ListForCommon()
        {
            return ListForCompany().Where(x => x.ProjectId == null).ToList();
        }

        public static List<OvertimeLimit> ListForProject(int projectId)
        {
            return ListForCompany().Where(x => x.ProjectId == projectId).ToList();
        }

        public static OvertimeLimit GetOvertime(int projectId, int empNum)
        {
            var code = Employee.GetEmployee(empNum).OvertimeCode;

            if (!string.IsNullOrEmpty(code))
            {
                return ListForProject(projectId).SingleOrDefault(x => x.Code == code) ?? ListForCommon().SingleOrDefault(x => x.Code == code);
            }

            return null;
        }

        public decimal Calc(decimal dayHours, decimal weekHours)
        {
            decimal overHoursByDay = Math.Max(dayHours - (DailyLimit ?? decimal.MaxValue), 0);
            decimal overHoursByWeek = Math.Max(weekHours - (WeeklyLimit ?? decimal.MaxValue), 0);

            decimal overHours = Math.Max(overHoursByDay, overHoursByWeek);
            return overHours;
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
