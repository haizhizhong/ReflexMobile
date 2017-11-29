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
    [RoutePrefix("api/LabourTemplates")]
    public class LabourTemplatesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select cwce_id, emp_no, e.cwc_id, start_date, end_date, c.pri_id, c.WC_Code from costing_work_class_emp e join costing_work_class c on e.cwc_id = c.cwc_id";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<LabourTemplate> list = new List<LabourTemplate>();
                table.Select().ToList().ForEach(r => list.Add(new LabourTemplate
                {
                    MatchId = r.Field<int>("cwce_id"),
                    CompanyId = companyId,
                    ProjectId = r.Field<int>("pri_id"),
                    EmpNum = r.Field<int>("emp_no"),
                    WorkClassCode = r.Field<string>("WC_Code"),
                    StartDate = r.Field<DateTime?>("start_date"),
                    EndDate = r.Field<DateTime?>("end_date"),
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
