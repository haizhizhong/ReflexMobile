using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/LabourTemplates")]
    public class LabourTemplatesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = "select cwce_id, emp_no, cwc_id, start_date, end_date from costing_work_class_emp";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<LabourTemplate> list = new List<LabourTemplate>();
            table.Select().ToList().ForEach(r => list.Add(new LabourTemplate
            {
                MatchId = r.Field<int>("cwce_id"),
                CompanyId = companyId,
                EmpNum = r.Field<int>("emp_no"),
                ProjectWorkClassId = r.Field<int>("cwc_id"),
                StartDate = r.Field<DateTime?>("start_date"),
                EndDate = r.Field<DateTime?>("end_date"),
            }));

            return Ok(list);
        }
    }
}
