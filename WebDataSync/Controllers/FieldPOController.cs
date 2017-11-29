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
    [RoutePrefix("api/FieldPO")]
    public class FieldPOController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId, int syncId)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("WS_FLEM_POHeader_Get", sqlcon);
                        da.SelectCommand.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@SyncId", syncId));
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable table = new DataTable();
                        da.Fill(table);
                        List<string[]> list = table.Select().Select(r => new string[]{ Convert.ToInt32(r["matchID"]).ToString(), Convert.ToString(r["PO"]) }).ToList();
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
        public IHttpActionResult Post(int syncId, [FromBody] FieldPO po)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_POHeader_PostPut";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraMatchId;
                    SqlParameter paraPONum;
                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmd.Parameters.Add(new SqlParameter("@ContactId", po.CreatorId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", po.CompanyId));
                    cmd.Parameters.Add(paraMatchId = new SqlParameter("@MatchId", po.MatchId) { Direction = ParameterDirection.InputOutput });
                    cmd.Parameters.Add(paraPONum = new SqlParameter("@PONum", po.PONum) { Direction = ParameterDirection.InputOutput, Size=20 });
                    cmd.Parameters.Add(new SqlParameter("@PODate", po.PODate));
                    cmd.Parameters.Add(new SqlParameter("@SupplierCode", po.SupplierCode));
                    cmd.Parameters.Add(new SqlParameter("@ProjectId", po.ProjectId));
                    cmd.ExecuteNonQuery();

                    string sqlDetail = @"WS_FLEM_PODetail_PostPut";
                    SqlCommand cmdDetail = new SqlCommand(sqlDetail, sqlcon);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmdDetail.Parameters.Add(new SqlParameter("@CompanyId", po.CompanyId));
                    cmdDetail.Parameters.Add(new SqlParameter("@MatchId", -1) { Direction = ParameterDirection.InputOutput });
                    cmdDetail.Parameters.Add(new SqlParameter("@HeaderMatchId", paraMatchId.Value));
                    cmdDetail.Parameters.Add(new SqlParameter("@LineNum", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@Description", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@Level1Id", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@Level2Id", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@Level3Id", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@Level4Id", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@LEMComp", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@Billable", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@Amount", null));

                    foreach (var detail in po.DetailList)
                    {
                        cmdDetail.Parameters["@LineNum"].Value = detail.LineNum;
                        cmdDetail.Parameters["@Description"].Value = detail.Description;
                        cmdDetail.Parameters["@MatchId"].Value = -1;
                        cmdDetail.Parameters["@Level1Id"].Value = (object)detail.Level1Id ?? DBNull.Value;
                        cmdDetail.Parameters["@Level2Id"].Value = (object)detail.Level2Id ?? DBNull.Value;
                        cmdDetail.Parameters["@Level3Id"].Value = (object)detail.Level3Id ?? DBNull.Value;
                        cmdDetail.Parameters["@Level4Id"].Value = (object)detail.Level4Id ?? DBNull.Value;
                        cmdDetail.Parameters["@LEMComp"].Value = (char)detail.Component;
                        cmdDetail.Parameters["@Billable"].Value = detail.Billable;
                        cmdDetail.Parameters["@Amount"].Value = detail.Amount;

                        cmdDetail.ExecuteNonQuery();
                    }

                    string[] returnData = new string[] { paraMatchId.Value.ToString(), paraPONum.Value.ToString() };
                    return Ok(returnData);
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
