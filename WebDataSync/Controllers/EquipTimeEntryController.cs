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
    [RoutePrefix("api/EquipTimeEntry")]
    public class EquipTimeEntryController : ApiController
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

                    string sSQL = @"WS_FLEM_LEMEquip_Get";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@contactId", contactId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));
                    cmd.Parameters.Add(new SqlParameter("@LastSyncTime", (object)lastUpdateTime ?? DBNull.Value));

                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());

                    List<EquipTimeEntry> list = table.Select().Select(r => new EquipTimeEntry
                    {
                        MatchId = (int)r["MatchId"],
                        CompanyId = companyId,
                        HeaderId = (int)r["HeaderMatchId"],
                        EqpNum = $"{r["eqi_num"]}",
                        ChangeOrderId = ConvertEx.ToNullable<int>(r["EstId"]),
                        Level1Id = ConvertEx.ToNullable<int>(r["lv1_id"]),
                        Level2Id = ConvertEx.ToNullable<int>(r["lv2_id"]),
                        Level3Id = ConvertEx.ToNullable<int>(r["lv3_id"]),
                        Level4Id = ConvertEx.ToNullable<int>(r["lv4_id"]),
                        Billable = (bool)r["Billable"],
                        Quantity = Convert.ToDecimal(r["Quantity"]),
                        BillCycle = (Equipment.EnumBillCycle)(Convert.ToChar(r["BillCycle"])),
                        BillAmount = ConvertEx.ToNullable<decimal>(r["dollars_total"]),
                    }).ToList();

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
        public IHttpActionResult Post(int syncId, [FromBody] EquipTimeEntry entry)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_EquipTimeEntry_PostPut";
                    SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraMatchId;
                    cmd.Parameters.Add(new SqlParameter("@SyncId", syncId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", entry.CompanyId));
                    cmd.Parameters.Add(paraMatchId = new SqlParameter("@MatchId", entry.MatchId) { Direction = ParameterDirection.InputOutput });
                    cmd.Parameters.Add(new SqlParameter("@HeaderMatchId", entry.HeaderId));
                    cmd.Parameters.Add(new SqlParameter("@EqpNum", entry.EqpNum));
                    cmd.Parameters.Add(new SqlParameter("@Level1Id", (object)entry.Level1Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Level2Id", (object)entry.Level2Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Level3Id", (object)entry.Level3Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Level4Id", (object)entry.Level4Id ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Billable", entry.Billable));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", entry.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@BillCycle", (char)entry.BillCycle));
                    cmd.Parameters.Add(new SqlParameter("@BillAmount", (object)entry.BillAmount ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@EstId", (object)entry.ChangeOrderId ?? DBNull.Value));
                    cmd.ExecuteNonQuery();

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
