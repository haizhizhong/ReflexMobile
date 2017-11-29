using System;
using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebDataSync.Security;
using ReflexCommon;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/LevelFourCodes")]
    public class LevelFourCodesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select lv4ID, lv3ID, lv4_code, lv4_desc from Level4_Codes";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<LevelFourCode> list = new List<LevelFourCode>();
                table.Select().ToList().ForEach(r => list.Add(new LevelFourCode
                {
                    MatchId = (int)r["lv4ID"],
                    CompanyId = companyId,
                    Level3Id = (int)r["lv3ID"],
                    Code = $"{r["lv4_code"]}",
                    Desc = $"{r["lv4_desc"]}",
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
