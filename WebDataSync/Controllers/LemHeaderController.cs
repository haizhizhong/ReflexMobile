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
    [RoutePrefix("api/LemHeader")]
    public class LemHeaderController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId, string clientMac, int contactId)
        {
            try
            {
                DateTime? lastUpdateTime = WebCommon.GetSyncTime(companyId, clientMac);

                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_LEMHeader_Get";
                    using (SqlCommand cmd = new SqlCommand(sSQL, sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@contactId", contactId));
                        cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                        cmd.Parameters.Add(new SqlParameter("@LastSyncTime", (object)lastUpdateTime ?? DBNull.Value));

                        DataTable table = new DataTable();
                        table.Load(cmd.ExecuteReader());

                        List<LemHeader> list = table.Select().Select(r => new LemHeader
                        {
                            MatchId = r.Field<int>("MatchId"),
                            CompanyId = companyId,
                            LogDate = r.Field<DateTime>("LogDate"),
                            LogStatus = (EnumLogStatus)Enum.Parse(typeof(EnumLogStatus), $"{r["LogStatus"]}"),
                            ProjectId = r.Field<int>("pri_ID"),
                            LemNum = Convert.ToString(r["LemNum"]),
                            CreatorId = r.Field<int>("LogCreatedBy"),
                            Description = Convert.ToString(r["Description"]),
                            ApprovalComments = Convert.ToString(r["ApprovalComments"]),
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

        [HttpPost]
        public IHttpActionResult Post(int syncId, [FromBody] LemHeader log)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_LogHeader_PostPut";
                    using (SqlCommand cmd = new SqlCommand(sSQL, sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraMatchId;
                        SqlParameter paraLemNum;
                        cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                        cmd.Parameters.Add(new SqlParameter("@ContactId", log.CreatorId));
                        cmd.Parameters.Add(new SqlParameter("@CompanyId", log.CompanyId));
                        cmd.Parameters.Add(paraMatchId = new SqlParameter("@MatchId", log.MatchId) { Direction = ParameterDirection.InputOutput });
                        cmd.Parameters.Add(new SqlParameter("@LogDate", log.LogDate));
                        cmd.Parameters.Add(new SqlParameter("@LogStatus", Enum.GetName(typeof(EnumLogStatus), log.LogStatus)));
                        cmd.Parameters.Add(new SqlParameter("@ProjectId", log.ProjectId));
                        cmd.Parameters.Add(paraLemNum = new SqlParameter("@LemNum", log.LemNum) { Direction = ParameterDirection.InputOutput, Size = 20 });
                        cmd.Parameters.Add(new SqlParameter("@BillAmount", log.BillAmount));
                        cmd.Parameters.Add(new SqlParameter("@Description", ConvertEx.DbNullable(log.Description)));
                        cmd.Parameters.Add(new SqlParameter("@EmailData", SqlDbType.VarBinary, log.EmailData?.Length ?? 0)).Value = ConvertEx.DbNullable(log.EmailData);
                        cmd.ExecuteNonQuery();

                        string[] returnData = new string[] { paraMatchId.Value.ToString(), paraLemNum.Value.ToString() };
                        return Ok(returnData);
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
