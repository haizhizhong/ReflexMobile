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
    [RoutePrefix("api/LabourTimeEntry")]
    public class LabourTimeEntryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId, string clientMac, int contactId)
        {
            try
            {
                DateTime? lastUpdateTime = WebCommon.GetSyncTime(companyId, clientMac);

                DataSet ds = new DataSet();
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("WS_FLEM_LEMLab_Get", sqlcon);
                        da.SelectCommand.Parameters.Add(new SqlParameter("@contactId", contactId));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@LastSyncTime", (object)lastUpdateTime ?? DBNull.Value));
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.Fill(ds, "Labour");

                        da.SelectCommand = new SqlCommand("WS_FLEM_LEMLabHrs_Get", sqlcon);
                        da.SelectCommand.Parameters.Add(new SqlParameter("@contactId", contactId));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@LastSyncTime", (object)lastUpdateTime ?? DBNull.Value));
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.Fill(ds, "LabourDetails");
                    }
                }

                List<LabourTimeEntry> list = ds.Tables["Labour"].Select().Select(r => new LabourTimeEntry
                {
                    MatchId = (int)r["MatchId"],
                    CompanyId = companyId,
                    HeaderId = (int)r["HeaderMatchId"],
                    EmpNum = (int)r["emp_no"],
                    ChangeOrderId = ConvertEx.ToNullable<int>(r["EstId"]),
                    Level1Id = ConvertEx.ToNullable<int>(r["lv1_id"]),
                    Level2Id = ConvertEx.ToNullable<int>(r["lv2_id"]),
                    Level3Id = ConvertEx.ToNullable<int>(r["lv3_id"]),
                    Level4Id = ConvertEx.ToNullable<int>(r["lv4_id"]),
                    Billable = (bool)r["Billable"],
                    Manual = ConvertEx.ToNullable<bool>(r["Manual"]) ?? false,
                    WorkClassCode = (string)r["wc_code"],
                    IncludedHours = ConvertEx.ToNullable<decimal>(r["IncludedHours"]),
                    TotalHours = ConvertEx.ToNullable<decimal>(r["hrs_total"]),
                    BillAmount = ConvertEx.ToNullable<decimal>(r["dollars_total"]),
                }).ToList();

                foreach (LabourTimeEntry entry in list)
                {
                    entry.DetailList = ds.Tables["LabourDetails"].Select().Where(x => (int)x["EntryMatchId"] == entry.MatchId).Select(d => new LabourTimeDetail
                    {
                        DetailId = (int)d["id"],
                        CompanyId = companyId,
                        EntryId = entry.MatchId,
                        TimeCodeId = (int)d["time_code_id"],
                        BillRate = ConvertEx.ToNullable<decimal>(d["BillRate"]),
                        WorkHours = ConvertEx.ToNullable<decimal>(d["WorkHours"]),
                        Amount = ConvertEx.ToNullable<decimal>(d["Amount"]),
                    }).ToList();
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(int syncId, [FromBody] LabourTimeEntry entry)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_LabourTimeEntry_PostPut";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraMatchId;
                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", entry.CompanyId));
                    cmd.Parameters.Add(paraMatchId = new SqlParameter("@MatchId", entry.MatchId) { Direction = ParameterDirection.InputOutput });
                    cmd.Parameters.Add(new SqlParameter("@HeaderMatchId", entry.HeaderId));
                    cmd.Parameters.Add(new SqlParameter("@EmpNum", entry.EmpNum));
                    cmd.Parameters.Add(new SqlParameter("@Level1Id", (object)entry.Level1Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Level2Id", (object)entry.Level2Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Level3Id", (object)entry.Level3Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Level4Id", (object)entry.Level4Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Billable", entry.Billable));
                    cmd.Parameters.Add(new SqlParameter("@Manual", entry.Manual));
                    cmd.Parameters.Add(new SqlParameter("@wcCode", entry.WorkClassCode));
                    cmd.Parameters.Add(new SqlParameter("@IncludedHours", (object)entry.IncludedHours ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TotalHours", (object)entry.TotalHours ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@BillAmount", (object)entry.BillAmount ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@EstId", (object)entry.ChangeOrderId ?? DBNull.Value));
                    cmd.ExecuteNonQuery();

                    string sqlDetail = @"WS_FLEM_LabourTimeDetail_PostPut";
                    SqlCommand cmdDetail = new SqlCommand(sqlDetail, sqlcon);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmdDetail.Parameters.Add(new SqlParameter("@CompanyId", entry.CompanyId));
                    cmdDetail.Parameters.Add(new SqlParameter("@EntryId", paraMatchId.Value));
                    cmdDetail.Parameters.Add(new SqlParameter("@TimeCodeId", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@WorkHours", null));
                    cmdDetail.Parameters.Add(new SqlParameter("@BillAmount", null));

                    foreach (var detail in entry.DetailList)
                    {
                        cmdDetail.Parameters["@TimeCodeId"].Value = detail.TimeCodeId;
                        if (detail.Amount == null)
                        {
                            cmdDetail.Parameters["@WorkHours"].Value = detail.WorkHours ?? 0;
                            cmdDetail.Parameters["@BillAmount"].Value = detail.BillRate ?? 0;
                        }
                        else
                        {
                            cmdDetail.Parameters["@WorkHours"].Value = detail.Amount;
                            cmdDetail.Parameters["@BillAmount"].Value = 1;
                        }

                        cmdDetail.ExecuteNonQuery();
                    }

                    return Ok(paraMatchId.Value);
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
