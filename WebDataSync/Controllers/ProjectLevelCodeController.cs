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
    [RoutePrefix("api/ProjectLevelCode")]
    public class ProjectLevelCodeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int contactId, int companyId)
        {
            try
            {
                var nullableConvert = new Func<object, int?>((obj) =>
                {
                    int v = Convert.ToInt32(obj);
                    return v == -1 ? null : (int?)v;
                });

                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_ProjBudget_Get ";
                    using (SqlCommand cmd = new SqlCommand(sSQL, sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@contactId", contactId));
                        cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));

                        DataTable table = new DataTable();
                        table.Load(cmd.ExecuteReader());

                        List<ProjectLevelCode> list = table.Select().Select(r => new ProjectLevelCode
                        {
                            CompanyId = companyId,
                            ProjectId = Convert.ToInt32(r["pri_id"]),
                            Level1Id = nullableConvert(r["lv1id"]),
                            Level2Id = nullableConvert(r["lv2id"]),
                            Level3Id = nullableConvert(r["lv3id"]),
                            Level4Id = nullableConvert(r["lv4id"]),
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
