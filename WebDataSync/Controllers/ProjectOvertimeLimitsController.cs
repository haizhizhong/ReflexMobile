using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/ProjectOvertimeLimits")]
    public class ProjectOvertimeLimitsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = "select ol_id, pri_id, ol_code, ol_desc, ol_ot, ol_dt, ol_week_ot, ol_week_dt from ot_limit";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<ProjectOvertimeLimit> list = new List<ProjectOvertimeLimit>();
            table.Select().ToList().ForEach(r => list.Add(new ProjectOvertimeLimit
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
    }
}
