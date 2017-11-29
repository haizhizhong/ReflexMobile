using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class TimeCode       //WS_EMP_Time_Code
    {
        public enum EnumValueType { Dollars, Hours };
        public enum EnumBillingRateType { Regular, Overtime, Travel, DoubleTime, Unknown};

        public int Id;
        public int MatchId;
        public int CompanyId;
        public string Desc;
        public EnumValueType ValueType;
        public EnumBillingRateType BillingType;
        public bool IncludedInWeekCalc;
        public int? OvertimeId;                      // only applied for regular 
        public int? DoubleTimeId;                    // only applied for regular
        public EnumComponentType Component;
        public string ReportTypeColumn;

        static List<TimeCode> _list;

        static List<TimeCode> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from TimeCode");
                    _list = table.Select().Select(r => new TimeCode
                    {
                        Id = (int)r["ID"],
                        MatchId = (int)r["MatchId"],
                        CompanyId = (int)r["CompanyId"],
                        Desc = (string)r["Desc"],
                        ValueType = ConvertEx.StringToEnum<EnumValueType>(r["ValueType"]),
                        BillingType = ConvertEx.StringToEnum<EnumBillingRateType>(r["BillingRateType"]),
                        IncludedInWeekCalc = (bool)r["IncludedInWeekCalc"],
                        OvertimeId = ConvertEx.ToNullable<int>(r["OvertimeId"]),
                        DoubleTimeId = ConvertEx.ToNullable<int>(r["DoubleTimeId"]),
                        Component = ConvertEx.CharToEnum<EnumComponentType>(r["Component"]),
                        ReportTypeColumn = Convert.ToString(r["ReportTypeColumn"]),
                    }).ToList();
                }
                return _list;
            }
        }

        public static List<TimeCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<TimeCode> SubList(EnumValueType type)
        {
            return ListForCompany().Where(x => x.ValueType == type).ToList();
        }

        public static TimeCode GetTimeCode(int matchId)
        {
            return ListForCompany().SingleOrDefault(x => x.MatchId == matchId);
        }

        public static List<TimeCode> GetTimeCodeList(EnumBillingRateType type)
        {
            return ListForCompany().Where(x => x.BillingType == type).ToList();
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
