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
    [RoutePrefix("api/EquipmentAssignments")]
    public class EquipmentAssignmentsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = "select eqi_num, emp_no, ea_date, ea_release_date, eg_code, ec_code from equip_assign";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<EquipmentAssignment> list = new List<EquipmentAssignment>();
                table.Select().ToList().ForEach(r => list.Add(new EquipmentAssignment
                {
                    CompanyId = companyId,
                    EqpNum = $"{r["eqi_num"]}",
                    EmpNum = (int)r["emp_no"],
                    AssignedDate = r.Field<DateTime?>("ea_date"),
                    ReleasedDate = r.Field<DateTime?>("ea_release_date"),
                    EarnGroup = Convert.ToString(r["eg_code"]),
                    EarnCode = Convert.ToString(r["ec_code"]),
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
