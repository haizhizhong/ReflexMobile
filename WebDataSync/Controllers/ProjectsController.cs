using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/Projects")]
    public class ProjectsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = $"select pri_id, pri_name, pri_code, ph.customer_id, c.customer_Code, c.Name, c.Bill_Address_1, pri_site1, pri_start_date, pri_est_completion_date, billable " +
                $"from dbo.proj_header ph join customers c on c.customer_id = ph.customer_id";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<Project> list = new List<Project>();
            table.Select().ToList().ForEach(r => list.Add(new Project
            {
                MatchId = r.Field<int>("pri_id"),
                CompanyId = companyId,
                Name = r.Field<string>("pri_name"),
                Code = r.Field<int>("pri_code"),
                CustomerId = r.Field<int>("customer_id"),
                CustomerCode = r.Field<string>("customer_Code"),
                CustomerName = r.Field<string>("Name"),
                CustomerAddress = r.Field<string>("Bill_Address_1"),
                SiteLocation = r.Field<string>("pri_site1"),
                StartDate = r.Field<DateTime?>("pri_start_date"),
                EstCompletionDate = r.Field<DateTime?>("pri_est_completion_date"),
                Billable = r.Field<bool>("billable")
            }));

            return Ok(list);
        }
    }
}
