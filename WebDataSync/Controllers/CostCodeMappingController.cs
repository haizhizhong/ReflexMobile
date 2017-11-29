using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WebDataSync.Security;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/CostCodeMapping")]
    public class CostCodeMappingController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int contactId, int companyId)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_LVCostCode_Get";
                    using (SqlCommand cmd = new SqlCommand(sSQL, sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@contactId", contactId));
                        cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));

                        DataTable table = new DataTable();
                        table.Load(cmd.ExecuteReader());

                        List<CostCodeMapping> list = table.Select().Select(r => new CostCodeMapping
                        {
                            CompanyId = companyId,
                            ProjectId = Convert.ToInt32(r["pri_id"]),
                            MappingId = Convert.ToInt32(r["level_id"]),
                            MappingCode = Convert.ToString(r["cost_code"]),
                        }).ToList();

                        return Ok(list);
                    }
                }
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
