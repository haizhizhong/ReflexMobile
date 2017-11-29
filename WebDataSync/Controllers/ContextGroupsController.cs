using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/ContextGroups")]
    public class ContextGroupsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable table = SqlCommon.ExecuteDataAdapter("WS_FLEM_ContextGroup_Get", WebCommon.WebConnection);

                List<ContextGroup> list = new List<ContextGroup>();
                table.Select().ToList().ForEach(r => list.Add(new ContextGroup
                {
                    ID = (int)r["Id"],
                    Name = (string)r["Name"],
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
