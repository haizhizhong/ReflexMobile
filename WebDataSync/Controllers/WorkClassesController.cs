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
    [RoutePrefix("api/WorkClasses")]
    public class WorkClassesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select Id, wc_code, wc_desc, Regular, OverTime, DoubleTime, Travel from work_class";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<WorkClass> list = new List<WorkClass>();
                table.Select().ToList().ForEach(r => list.Add(new WorkClass
                {
                    MatchId = (int)r["Id"],
                    CompanyId = companyId,
                    Code = $"{r["wc_code"]}",
                    Desc = $"{r["wc_desc"]}",
                    RegularBillRate = r.Field<decimal?>("Regular"),
                    OvertimeBillRate = r.Field<decimal?>("OverTime"),
                    DoubleTimeBillRate = r.Field<decimal?>("DoubleTime"),
                    TravelBillRate = r.Field<decimal?>("Travel")
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
