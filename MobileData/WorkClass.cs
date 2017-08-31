using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.TimeCode;

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

        public Dictionary<EnumBillingRateType, decimal> BillRateList;

        static List<WorkClass> _list;

        public static List<WorkClass> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WorkClass>();
                    DataTable table = Common.ExecuteDataAdapter("select * from WorkClass");
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

                        AddBillingRate(EnumBillingRateType.Regular, r.Field<decimal?>("RegularBillRate"));
                        AddBillingRate(EnumBillingRateType.Overtime, r.Field<decimal?>("OvertimeBillRate"));
                        AddBillingRate(EnumBillingRateType.Travel, r.Field<decimal?>("DoubleTimeBillRate"));
                        AddBillingRate(EnumBillingRateType.DoubleTime, r.Field<decimal?>("TravelBillRate"));

                        _list.Add(new WorkClass
                        {
                            Id = (int)r["Id"],
                            MatchId = (int)r["MatchId"],
                            CompanyId = (int)r["CompanyId"],
                            Code = $"{r["Code"]}",
                            Desc = $"{r["Desc"]}",
                            RegularBillRate = r.Field<decimal?>("RegularBillRate"),
                            OvertimeBillRate = r.Field<decimal?>("OvertimeBillRate"),
                            DoubleTimeBillRate = r.Field<decimal?>("DoubleTimeBillRate"),
                            TravelBillRate = r.Field<decimal?>("TravelBillRate"),
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

        public static WorkClass GetWorkClass(int id)
        {
            return List.SingleOrDefault(x => x.MatchId == id && x.CompanyId == Company.CurrentId);
        }

        public static WorkClass GetWorkClass(string code)
        {
            return List.SingleOrDefault(x => x.Code == code && x.CompanyId == Company.CurrentId);
        }

        public static void Refresh()
        {
            _list = null;
        }

        public static void Sync(int companyId, List<WorkClass> list)
        {
            string sql = $"delete WorkClass where companyId = {companyId}";
            Common.ExecuteNonQuery(sql);

            list.ForEach(x =>
            {
                sql = $"insert WorkClass(MatchId, companyId, Code, [Desc], RegularBillRate, OvertimeBillRate, DoubletimeBillRate, TravelBillRate) " +
                  $"values({x.MatchId}, {x.CompanyId}, '{x.Code}', '{x.Desc}', {StringEx.ToValueOrNull(x.RegularBillRate)}, {StringEx.ToValueOrNull(x.OvertimeBillRate)}, {StringEx.ToValueOrNull(x.DoubleTimeBillRate)}, {StringEx.ToValueOrNull(x.TravelBillRate)})";
                Common.ExecuteNonQuery(sql);
            });

            Refresh();
        }
    }
}
