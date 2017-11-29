using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.TimeCode;
using ReflexCommon;

namespace MobileData
{
    public class WorkClass      //work_class
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public string Code;
        public string Desc;

        public decimal? RegularBillRate;
        public decimal? OvertimeBillRate;
        public decimal? DoubleTimeBillRate;
        public decimal? TravelBillRate;

        public string DisplayName => $"{Desc} ({Code})";

        public Dictionary<EnumBillingRateType, decimal> BillRateList;

        static List<WorkClass> _list;

        static List<WorkClass> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WorkClass>();
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from WorkClass");
                    table.Select().ToList().ForEach(r =>
                    {
                        Dictionary<EnumBillingRateType, decimal> rateList = new Dictionary<EnumBillingRateType, decimal>();

                        var AddBillingRate = new Action<TimeCode.EnumBillingRateType, decimal?>((type, value) =>
                        {
                            if (value != null)
                            {
                                rateList.Add(type, value.Value);
                            }
                        });

                        AddBillingRate(EnumBillingRateType.Regular, ConvertEx.ToNullable<decimal>(r["RegularBillRate"]));
                        AddBillingRate(EnumBillingRateType.Overtime, ConvertEx.ToNullable<decimal>(r["OvertimeBillRate"]));
                        AddBillingRate(EnumBillingRateType.DoubleTime, ConvertEx.ToNullable<decimal>(r["DoubleTimeBillRate"]));
                        AddBillingRate(EnumBillingRateType.Travel, ConvertEx.ToNullable<decimal>(r["TravelBillRate"]));

                        _list.Add(new WorkClass
                        {
                            Id = (int)r["Id"],
                            MatchId = (int)r["MatchId"],
                            CompanyId = (int)r["CompanyId"],
                            Code = (string)r["Code"],
                            Desc = (string)r["Desc"],
                            RegularBillRate = ConvertEx.ToNullable<decimal>(r["RegularBillRate"]),
                            OvertimeBillRate = ConvertEx.ToNullable<decimal>(r["OvertimeBillRate"]),
                            DoubleTimeBillRate = ConvertEx.ToNullable<decimal>(r["DoubleTimeBillRate"]),
                            TravelBillRate = ConvertEx.ToNullable<decimal>(r["TravelBillRate"]),
                            BillRateList = rateList
                        });
                    });
                }
                return _list;
            }
        }

        public static List<WorkClass> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static WorkClass GetWorkClass(int matchId)
        {
            return ListForCompany().SingleOrDefault(x => x.MatchId == matchId);
        }

        public static WorkClass GetWorkClass(string code)
        {
            return ListForCompany().SingleOrDefault(x => x.Code == code);
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
