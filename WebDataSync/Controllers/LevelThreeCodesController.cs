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
    [RoutePrefix("api/LevelThreeCodes")]
    public class LevelThreeCodesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select lv3ID, lv2ID, lv3_code, lv3_desc from Level3_Codes";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<LevelThreeCode> list = new List<LevelThreeCode>();
                table.Select().ToList().ForEach(r => list.Add(new LevelThreeCode
                {
                    MatchId = (int)r["lv3ID"],
                    CompanyId = companyId,
                    Level2Id = (int)r["lv2ID"],
                    Code = $"{r["lv3_code"]}",
                    Desc = $"{r["lv3_desc"]}",
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
