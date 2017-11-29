using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/SecurityFunction")]
    public class SecurityFunctionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable table = SqlCommon.ExecuteDataAdapter("WS_FLEM_SecurityFunctionSync", WebCommon.WebConnection);

                List<SecurityFunction> list = new List<SecurityFunction>();
                table.Select().ToList().ForEach(r => list.Add(new SecurityFunction
                {
                    Id = (int)r["Id"],
                    ParentId = ConvertEx.ToNullable<int>(r["ParentId"]),
                    Description = (string)r["Description"],
                    FieldServices = (bool)r["FieldServices"]
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
