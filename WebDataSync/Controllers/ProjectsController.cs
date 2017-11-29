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
    [RoutePrefix("api/Projects")]
    public class ProjectsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select pri_id, pri_name, pri_code, ph.customer_id, pri_site1, pri_start_date, pri_est_completion_date, billable, Customer_File_Num, " +
                    $"site_address, site_city, site_state, site_zip, c.customer_Code, c.Name, c.Bill_Address_1, c.bill_address_2, c.bill_address_3, c.bill_city, " +
                    $"c.bill_state, c.bill_zip, Pri_desc from dbo.proj_header ph join customers c on c.customer_id = ph.customer_id where ph.pri_type = 'pgc' and ph.pri_status='A'";

                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));
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
                    Billable = r.Field<bool>("billable"),
                    POReference = Convert.ToString(r["Customer_File_Num"]),
                    SiteAddress = Convert.ToString(r["site_address"]),
                    SiteCity = Convert.ToString(r["site_city"]),
                    SiteState = Convert.ToString(r["site_state"]),
                    SiteZip = Convert.ToString(r["site_zip"]),
                    CustomerAddress2 = Convert.ToString(r["bill_address_2"]),
                    CustomerAddress3 = Convert.ToString(r["bill_address_3"]),
                    CustomerCity = Convert.ToString(r["bill_city"]),
                    CustomerState = Convert.ToString(r["bill_state"]),
                    CustomerZip = Convert.ToString(r["bill_zip"]),
                    ProjectExtendedDescription = Convert.ToString(r["Pri_desc"])
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
    