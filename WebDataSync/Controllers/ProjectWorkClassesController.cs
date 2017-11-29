using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebDataSync.Security;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/ProjectWorkClasses")]
    public class ProjectWorkClassesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = @"select cwc_id, pri_id, WC_Code, Standard, OverTime, Doubletime, TravelTime, isnull(sch_enabled, 'false') Schedulable, CeilingCost, sch_bud_hrs_reg, sch_bud_hrs_tt from costing_work_class";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                Func<double?, decimal?> ZeroToNull = new Func<double?, decimal?>((value) =>
                {
                    return (value == null || value.Value == 0.0) ? null : (decimal?)value;
                });

                List<ProjectWorkClass> list = new List<ProjectWorkClass>();
                table.Select().ToList().ForEach(r => list.Add(new ProjectWorkClass
                {
                    MatchId = r.Field<int>("cwc_id"),
                    CompanyId = companyId,
                    ProjectId = r.Field<int>("pri_id"),
                    WorkClassCode = r.Field<string>("WC_Code"),
                    Schedulable = r.Field<bool>("Schedulable"),
                    RegularBillRate = ZeroToNull(r.Field<double?>("Standard")),
                    OvertimeBillRate = ZeroToNull(r.Field<double?>("OverTime")),
                    DoubleTimeBillRate = ZeroToNull(r.Field<double?>("Doubletime")),
                    TravelBillRate = ZeroToNull(r.Field<double?>("TravelTime")),
                    CeilingCost = r.Field<decimal?>("CeilingCost"),
                    RegularHours = r.Field<decimal?>("sch_bud_hrs_reg"),
                    TravelHours = r.Field<decimal?>("sch_bud_hrs_tt"),
                }));

                return Ok(list);
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
