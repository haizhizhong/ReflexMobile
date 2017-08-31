using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = $"select emp_no, emp_first_name, emp_last_name, wc_code from Employee";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<Employee> list = new List<Employee>();
            table.Select().ToList().ForEach(r => list.Add(new Employee
            {
                EmpNum = (int)r["emp_no"],
                CompanyId = companyId,
                FirstName = (string)r["emp_first_name"],
                LastName = (string)r["emp_last_name"],
                WorkClassCode = (string)r["wc_code"]
            }));

            return Ok(list);
        }
    }
}
