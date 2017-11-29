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
    [RoutePrefix("api/OvertimeLimits")]
    public class OvertimeLimitsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = "select ol_id, pri_id, ol_code, ol_desc, ol_ot, ol_dt, ol_week_ot, ol_week_dt from ot_limit";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<OvertimeLimit> list = new List<OvertimeLimit>();
                table.Select().ToList().ForEach(r => list.Add(new OvertimeLimit
                {
                    MatchId = r.Field<int>("ol_id"),
                    CompanyId = companyId,
                    ProjectId = r.Field<int>("pri_id"),
                    Code = r.Field<string>("ol_code"),
                    Desc = r.Field<string>("ol_desc"),
                    DailyLimit = r.Field<decimal?>("ol_ot"),
                    DailyDoubleLimit = r.Field<decimal?>("ol_dt"),
                    WeeklyLimit = r.Field<decimal?>("ol_week_ot"),
                    WeeklyDoubleLimit = r.Field<decimal?>("ol_week_dt"),
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
