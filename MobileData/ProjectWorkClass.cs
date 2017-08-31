using System;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public bool Schedulable;

        public decimal? RegularBillRate;
        public decimal? OvertimeBillRate;
        public decimal? DoubleTimeBillRate;
        public decimal? TravelBillRate;

        public Dictionary<EnumBillingRateType, decimal> BillRateList;

        public decimal? CeilingCost;
        public decimal? RegularHours;
        public decimal? TravelHours;


        static List<ProjectWorkClass> _list;

        public static List<ProjectWorkClass> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ProjectWorkClass>();
                    DataTable table = Common.ExecuteDataAdapter("select * from ProjectWorkClass");
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

                        _list.Add(new ProjectWorkClass
                        {
                            Id = r.Field<int>("Id"),
                            MatchId = r.Field<int>("MatchId"),
                            CompanyId = r.Field<int>("CompanyId"),
                            ProjectId = r.Field<int>("ProjectId"),
                            WorkClassCode = r.Field<string>("WorkClassCode"),
                            Schedulable = r.Field<bool>("Schedulable"),
                            RegularBillRate = r.Field<decimal?>("RegularBillRate"),
                            OvertimeBillRate = r.Field<decimal?>("OvertimeBillRate"),
                            DoubleTimeBillRate = r.Field<decimal?>("DoubleTimeBillRate"),
                            TravelBillRate = r.Field<decimal?>("TravelBillRate"),
                            CeilingCost = r.Field<decimal?>("CeilingCost"),
                            RegularHours = r.Field<decimal?>("RegularHours"),
                            TravelHours = r.Field<decimal?>("TravelHours"),
                            BillRateList = rateList
                        });
                    });
                }
                return _list;
            }
        }

        public static decimal? GetBillRate( int projectId, int timeCodeId, int workClassId)
        {
            var billingType = TimeCode.GetTimeCode(timeCodeId).BillingType;

            var pwc = ListForProject(projectId).SingleOrDefault(x => x.MatchId == workClassId);
            Dictionary<EnumBillingRateType, decimal> rateList = new Dictionary<EnumBillingRateType, decimal>();
            if (pwc != null && pwc.BillRateList.ContainsKey(billingType))
                return pwc.BillRateList[billingType];

            var wc = WorkClass.GetWorkClass(workClassId);
            if (wc != null && wc.BillRateList.ContainsKey(billingType))
                return wc.BillRateList[billingType];

            return null;
        }

        public static List<ProjectWorkClass> ListForProject(int projectId)
        {
            return List.Where(x => x.ProjectId == projectId).ToList();
        }

        public static ProjectWorkClass GetProjectWorkClass(int id)
        {
            return List.SingleOrDefault( x => x.MatchId==id);
        }

        public static void Refresh()
        {
            _list = null;
        }

        public static async System.Threading.Tasks.Task Sync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Common.WebUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"api/ProjectWorkClasses?companyId={Company.CurrentId}");

                if (response.IsSuccessStatusCode)
                {
                    List<ProjectWorkClass> list = await response.Content.ReadAsAsync<List<ProjectWorkClass>>();

                    string sql = $"delete ProjectWorkClass where companyId = {Company.CurrentId}";
                    Common.ExecuteNonQuery(sql);

                    list.ForEach(x =>
                    {
                        sql = $"insert ProjectWorkClass(MatchId, CompanyId, ProjectId, WorkClassCode, RegularBillRate, OvertimeBillRate, DoubletimeBillRate, TravelBillRate, Schedulable, CeilingCost, RegularHours, TravelHours) " +
                          $"values({x.MatchId}, {x.CompanyId}, {x.ProjectId}, '{x.WorkClassCode}', {StringEx.ToValueOrNull(x.RegularBillRate)}, {StringEx.ToValueOrNull(x.OvertimeBillRate)}, {StringEx.ToValueOrNull(x.DoubleTimeBillRate)}, {StringEx.ToValueOrNull(x.TravelBillRate)}," +
                          $" '{x.Schedulable}', {StringEx.ToValueOrNull(x.CeilingCost)}, {StringEx.ToValueOrNull(x.RegularHours)}, {StringEx.ToValueOrNull(x.TravelHours)})";
                        Common.ExecuteNonQuery(sql);
                    });

                    Refresh();
                }
            }
        }
    }
}
