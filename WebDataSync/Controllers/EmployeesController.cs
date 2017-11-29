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
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select emp_no, emp_first_name, emp_last_name, wc_code, ol_code from Employee";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<Employee> list = new List<Employee>();
                table.Select().ToList().ForEach(r => list.Add(new Employee
                {
                    EmpNum = Convert.ToInt32(r["emp_no"]),
                    CompanyId = companyId,
                    FirstName = Convert.ToString(r["emp_first_name"]),
                    LastName = Convert.ToString(r["emp_last_name"]),
                    WorkClassCode = Convert.ToString(r["wc_code"]),
                    OvertimeCode = Convert.ToString(r["ol_code"]),
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
