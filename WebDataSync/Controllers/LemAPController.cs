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
    [RoutePrefix("api/LemAP")]
    public class LemAPController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId, string clientMac)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand("WS_FLEM_AP_GET", sqlcon);
                        da.SelectCommand.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.Fill(ds, "LemAp");

                        da.SelectCommand = new SqlCommand("WS_FLEM_APDet_Get", sqlcon);
                        da.SelectCommand.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.Fill(ds, "LemApDetails");
                    }
                }

                List<LemAP> list = new List<LemAP>();
                ds.Tables["LemAp"].Select().ToList().ForEach(r =>
                {
                    var lemAp = new LemAP
                    {
                        MatchId = Convert.ToInt32(r["ap_inv_header_id"]),
                        CompanyId = companyId,
                        ProjectId = Convert.ToInt32(r["pri_id"]),
                        InvoiceDate = Convert.ToDateTime(r["InvDate"]),
                        InvoiceNum = Convert.ToString(r["InvNo"]),
                        SupplierCode = Convert.ToString(r["SupplierCode"]),
                        PONum = Convert.ToString(r["PONo"]),
                        InvoiceAmount = Convert.ToDecimal(r["InvAmt"]),
                        MarkupAmount = Convert.ToDecimal(r["MarkupAmt"]),
                        BillAmount = Convert.ToDecimal(r["BillAmt"]),
                        DetailList = new List<LemAPDetail>()
                    };

                    ds.Tables["LemApDetails"].Select().Where(x => (int)x["ap_inv_header_id"] == lemAp.MatchId).ToList().ForEach(d =>
                    {
                        lemAp.DetailList.Add(new LemAPDetail
                        {
                            MatchId = Convert.ToInt32(d["ap_gl_alloc_id"]),
                            CompanyId = companyId,
                            LemAPId = lemAp.MatchId,
                            LineNum = Convert.ToInt32(d["Seq"]),
                            Description = Convert.ToString(d["Description"]),
                            Reference = Convert.ToString(d["Reference"]),
                            Amount = Convert.ToDecimal(d["Amount"]),
                            MarkupPercent = Convert.ToDecimal(d["MarkupPct"]),
                            MarkupAmount = Convert.ToDecimal(d["MarkupAmt"]),
                            BillAmount = Convert.ToDecimal(d["BillAmt"]),
                            Level1Id = ConvertEx.ToNullable<int>(d["lv1id"]),
                            Level2Id = ConvertEx.ToNullable<int>(d["lv2id"]),
                            Level3Id = ConvertEx.ToNullable<int>(d["lv3id"]),
                            Level4Id = ConvertEx.ToNullable<int>(d["lv4id"]),
                        });
                    });

                    list.Add(lemAp);
                });

                return Ok(list);
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(int syncId, [FromBody] LemAP ap)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_APDet_PostPut ";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", ap.CompanyId));
                    cmd.Parameters.Add(new SqlParameter("@HeaderMatchId", ap.HeaderId));
                    cmd.Parameters.Add(new SqlParameter("@ap_gl_alloc_id", null));
                    cmd.Parameters.Add(new SqlParameter("@Amount", null));
                    cmd.Parameters.Add(new SqlParameter("@MarkupPct", null));
                    cmd.Parameters.Add(new SqlParameter("@MarkupAmt", null));
                    cmd.Parameters.Add(new SqlParameter("@BillAmt", null));

                    foreach (var detail in ap.DetailList)
                    {
                        cmd.Parameters["@ap_gl_alloc_id"].Value = detail.MatchId;
                        cmd.Parameters["@Amount"].Value = detail.Amount;
                        cmd.Parameters["@MarkupPct"].Value = detail.MarkupPercent;
                        cmd.Parameters["@MarkupAmt"].Value = detail.MarkupAmount;
                        cmd.Parameters["@BillAmt"].Value = detail.BillAmount;
                        cmd.ExecuteNonQuery();
                    }

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