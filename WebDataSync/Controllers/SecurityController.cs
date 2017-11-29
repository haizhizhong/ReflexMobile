using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/Security")]
    public class SecurityController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable table = SqlCommon.ExecuteDataAdapter("WS_FLEM_SecuritySync", WebCommon.WebConnection);

                List<MobileData.Security> list = new List<MobileData.Security>();
                table.Select().ToList().ForEach(r => list.Add(new MobileData.Security
                {
                    Function_ID = (int)r["Function_ID"],
                    CompanyId = (int)r["CompanyId"],
                    Department = (string)r["Department"],
                }));

                return Ok(list);
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                DataTable table = SqlCommon.ExecuteDataAdapter("WS_FLEM_SecuritySync", WebCommon.WebConnection);

                List<MobileData.Security> list = new List<MobileData.Security>();
                table.Select().Where(x => (int)x["CompanyId"] == companyId).ToList().ForEach(r => list.Add(new MobileData.Security
                {
                    Function_ID = (int)r["Function_ID"],
                    CompanyId = (int)r["CompanyId"],
                    Department = (string)r["Department"],
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
