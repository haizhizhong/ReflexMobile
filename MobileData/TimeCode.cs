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

        static List<TimeCode> _list;

        public static List<TimeCode> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<TimeCode>();
                    DataTable table = Common.ExecuteDataAdapter("select * from TimeCode");
                    table.Select().ToList().ForEach(r => _list.Add(
                        new TimeCode
                        {
                            Id = (int)r["ID"],
                            MatchId = (int)r["MatchId"],
                            CompanyId = (int)r["CompanyId"],
                            Desc = $"{r["Desc"]}",
                            ValueType = (EnumValueType)Enum.Parse(typeof(EnumValueType), $"{r["ValueType"]}"),
                            BillingType = r["BillingRateType"]!=DBNull.Value ? (EnumBillingRateType)Enum.Parse(typeof(EnumBillingRateType), $"{r["BillingRateType"]}") : EnumBillingRateType.Unknown
                        }));
                }
                return _list;
            }
        }

        public static IEnumerable<TimeCode> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId);
        }

        public static List<TimeCode> SubList(EnumValueType type)
        {
            return ListForCompany().Where(x => x.ValueType == type).ToList();
        }

        public static TimeCode GetTimeCode(int id)
        {
            return List.SingleOrDefault(x => x.MatchId == id && x.CompanyId == Company.CurrentId);
        }

        public static void Refresh()
        {
            _list = null;
        }

        public static void Sync(int companyId, List<TimeCode> list)
        {
            string sql = $"delete TimeCode where companyId = {companyId}";
            Common.ExecuteNonQuery(sql);

            list.ForEach(x =>
            {
                sql = $"insert TimeCode(MatchId, companyId, [Desc], ValueType, BillingRateType) " +
                  $"values({x.MatchId}, {x.CompanyId}, '{x.Desc}', {x.ValueType}, {x.BillingType})";
                Common.ExecuteNonQuery(sql);
            });

            Refresh();
        }

    }
}
