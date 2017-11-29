using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebDataSync.Security;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/LevelTwoCodes")]
    public class LevelTwoCodesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select lv2ID, lv1ID, lv2_code, lv2_desc from Level2_Codes";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<LevelTwoCode> list = new List<LevelTwoCode>();
                table.Select().ToList().ForEach(r => list.Add(new LevelTwoCode
                {
                    MatchId = (int)r["lv2ID"],
                    CompanyId = companyId,
                    Level1Id = (int)r["lv1ID"],
                    Code = $"{r["lv2_code"]}",
                    Desc = $"{r["lv2_desc"]}",
                }));

                return Ok(list);
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
