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
    [RoutePrefix("api/DeleteHistory")]
    public class DeleteHistoryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int syncId)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_DeleteHistory_Get";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));

                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());

                    List<DeleteHistory> list = new List<DeleteHistory>();
                    table.Select().ToList().ForEach(r => list.Add(new DeleteHistory()
                    {
                        TableName = Convert.ToString(r["TableName"]),
                        CompanyId = Convert.ToInt32(r["CompanyId"]),
                        MatchId = Convert.ToInt32(r["MatchId"])
                    }));

                    return Ok(list);
                }
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(int syncId, [FromBody] DeleteHistory item)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_DeleteRecord";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmd.Parameters.Add(new SqlParameter("@TableName", item.TableName));
                    cmd.Parameters.Add(new SqlParameter("@MatchId", item.MatchId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", item.CompanyId));
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
