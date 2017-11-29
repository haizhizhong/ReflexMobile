using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/ContextUsages")]
    public class ContextUsagesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable table = SqlCommon.ExecuteDataAdapter("WS_FLEM_ContextUsage_Get", WebCommon.WebConnection);

                List<ContextUsage> list = new List<ContextUsage>();
                table.Select().ToList().ForEach(r => list.Add(new ContextUsage
                {
                    ID = (int)r["Id"],
                    ContextItemID = (int)r["ContextItemID"],
                    ContextGroupID = (int)r["ContextGroupID"],
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
