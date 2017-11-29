using MobileData;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using WebDataSync.Security;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/Attachments")]
    public class AttachmentsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(int syncId, [FromBody] Attachment attach)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_Attachment_PostPut";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraMatchId;
                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmd.Parameters.Add(paraMatchId = new SqlParameter("@MatchId", attach.MatchId ?? -1) { Direction = ParameterDirection.InputOutput });
                    cmd.Parameters.Add(new SqlParameter("@LinkMatchId", attach.LinkMatchId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", attach.CompanyId));
                    cmd.Parameters.Add(new SqlParameter("@ContextItemId", attach.ContextItemId));
                    cmd.Parameters.Add(new SqlParameter("@TableDotField", attach.TableDotField));
                    cmd.Parameters.Add(new SqlParameter("@Comment", (object)attach.Comment ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FileName", attach.FileName));
                    cmd.Parameters.Add(new SqlParameter("@FileData", attach.FileData));
                    cmd.Parameters.Add(new SqlParameter("@FileTypeDescription", (object)attach.FileTypeDescription ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DateAdded", attach.DateAdded));
                    cmd.Parameters.Add(new SqlParameter("@MimeType", attach.MimeType));
                    cmd.Parameters.Add(new SqlParameter("@ContactId", attach.ContactId));
                    cmd.Parameters.Add(new SqlParameter("@InternalOnly", attach.InternalOnly));
                    cmd.ExecuteNonQuery();

                    return Ok((int)paraMatchId.Value);
                }
            }
            catch (Exception e)
            {
                ReflexCommon.SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
