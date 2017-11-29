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
    [RoutePrefix("api/LevelOneCodes")]
    public class LevelOneCodesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select lv1ID, lv1_code, lv1_desc from Level1_Codes";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<LevelOneCode> list = new List<LevelOneCode>();
                table.Select().ToList().ForEach(r => list.Add(new LevelOneCode
                {
                    MatchId = (int)r["lv1ID"],
                    CompanyId = companyId,
                    Code = $"{r["lv1_code"]}",
                    Desc = $"{r["lv1_desc"]}",
                }));

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
