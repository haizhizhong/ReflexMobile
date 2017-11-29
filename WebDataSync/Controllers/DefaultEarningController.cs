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
    [RoutePrefix("api/DefaultEarning")]
    public class DefaultEarningController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int contactId, int companyId)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
                {
                    sqlcon.Open();

                    string sSQL = @"WS_FLEM_Defaults_Get";
                    using (SqlCommand cmd = new SqlCommand(sSQL, sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@contactId", contactId));
                        cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));

                        DataTable table = new DataTable();
                        table.Load(cmd.ExecuteReader());

                        List<DefaultEarning> list = table.Select().Select(r => new DefaultEarning
                        {
                            CompanyId = companyId,
                            ProjectId = Convert.ToInt32(r["pri_id"]),
                            Level1Id = ConvertEx.ToNullable<int>(r["lv1id"]),
                            Level2Id = ConvertEx.ToNullable<int>(r["lv2id"]),
                            Level3Id = ConvertEx.ToNullable<int>(r["lv3id"]),
                            Level4Id = ConvertEx.ToNullable<int>(r["lv4id"]),
                            EarningType = ConvertEx.CharToEnum<EnumEarningType>(r["type"])
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
