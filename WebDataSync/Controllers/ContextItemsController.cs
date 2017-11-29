using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/ContextItems")]
    public class ContextItemsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable table = SqlCommon.ExecuteDataAdapter("WS_FLEM_ContextItem_Get", WebCommon.WebConnection);

                List<ContextItem> list = new List<ContextItem>();
                table.Select().ToList().ForEach(r => list.Add(new ContextItem
                {
                    ID = (int)r["Id"],
                    ContextGroupID = (int)r["ContextGroupID"],
                    Name = Convert.ToString(r["Name"]),
                    WordMergeDSN = Convert.ToString(r["WordMergeDSN"]),
                    IsSystem = (bool)r["IsSystem"]
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
