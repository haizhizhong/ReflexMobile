using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using ReflexCommon;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/SyncProcess")]
    public class SyncProcessController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetSyncId(int companyId, string clientMac)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_SyncInit";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraSyncId;
                    cmd.Parameters.Add(paraSyncId = new SqlParameter("@SyncId", -1) { Direction = ParameterDirection.InputOutput });
                    cmd.Parameters.Add(new SqlParameter("@ClientMac", clientMac));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                    cmd.ExecuteNonQuery();

                    return Ok((int)paraSyncId.Value);
                }
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult CommitOrRollback(int syncId, [FromBody] bool commit)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = commit ? "WS_SyncEnd" : "WS_FLEM_SyncCancel";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmd.ExecuteNonQuery();

                    return Ok();
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
