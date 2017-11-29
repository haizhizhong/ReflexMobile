using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static MobileData.TimeCode;

namespace MobileData
{
    public class ProjectWorkClass   //costing_work_class
    {
        public int Id;
        public int MatchId;
        public int CompanyId;

        public int ProjectId;
        public string WorkClassCode;
        public string Desc;

        public bool Schedulable;

        public decimal? RegularBillRate;
        public decimal? OvertimeBillRate;
        public decimal? DoubleTimeBillRate;
        public decimal? TravelBillRate;

        public string DisplayName => $"{Desc} ({WorkClassCode})";

        public Dictionary<EnumBillingRateType, decimal> BillRateList;

        public decimal? CeilingCost;
        public decimal? RegularHours;
        public decimal? TravelHours;


        static List<ProjectWorkClass> _list;

        static List<ProjectWorkClass> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ProjectWorkClass>();
                    DataTable table = MobileCommon.ExecuteDataAdapter("select * from ProjectWorkClass");
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

                        _list.Add(new ProjectWorkClass
                        {
                            Id = (int)r["Id"],
                            MatchId = (int)r["MatchId"],
                            CompanyId = (int)r["CompanyId"],
                            ProjectId = (int)r["ProjectId"],
                            WorkClassCode = (string)r["WorkClassCode"],
                            Schedulable = (bool)r["Schedulable"],
                            RegularBillRate = ConvertEx.ToNullable<decimal>(r["RegularBillRate"]),
                            OvertimeBillRate = ConvertEx.ToNullable<decimal>(r["OvertimeBillRate"]),
                            DoubleTimeBillRate = ConvertEx.ToNullable<decimal>(r["DoubleTimeBillRate"]),
                            TravelBillRate = ConvertEx.ToNullable<decimal>(r["TravelBillRate"]),
                            CeilingCost = ConvertEx.ToNullable<decimal>(r["CeilingCost"]),
                            RegularHours = ConvertEx.ToNullable<decimal>(r["RegularHours"]),
                            TravelHours = ConvertEx.ToNullable<decimal>(r["TravelHours"]),
                            BillRateList = rateList,
                            Desc = WorkClass.GetWorkClass((string)r["WorkClassCode"])?.Desc ?? ""
                        });
                    });
                }
                return _list;
            }
        }

        public static decimal? GetBillRate(int projectId, int timeCodeId, string workClassCode)
        {
            var billingType = TimeCode.GetTimeCode(timeCodeId).BillingType;

            var pwc = ListForProject(projectId).SingleOrDefault(x => x.WorkClassCode == workClassCode);
            Dictionary<EnumBillingRateType, decimal> rateList = new Dictionary<EnumBillingRateType, decimal>();
            if (pwc != null && pwc.BillRateList.ContainsKey(billingType))
                return pwc.BillRateList[billingType];

            var wc = WorkClass.GetWorkClass(workClassCode);
            if (wc != null && wc.BillRateList.ContainsKey(billingType))
                return wc.BillRateList[billingType];

            return null;
        }

        public static List<ProjectWorkClass> ListForCompany()
        {
            return List.Where(x => x.CompanyId == Company.CurrentId).ToList();
        }

        public static List<ProjectWorkClass> ListForProject(int projectId)
        {
            return ListForCompany().Where(x => x.ProjectId == projectId).ToList();
        }

        public static void Refresh()
        {
            _list = null;
        }
    }
}
