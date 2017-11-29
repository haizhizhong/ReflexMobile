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
    [RoutePrefix("api/EquipmentCategories")]
    public class EquipmentCategoriesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = "select fac_code, fac_desc from fa_cat";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<EquipmentCategory> list = new List<EquipmentCategory>();
                table.Select().ToList().ForEach(r => list.Add(new EquipmentCategory
                {
                    CompanyId = companyId,
                    Code = r.Field<string>("fac_code"),
                    Desc = r.Field<string>("fac_desc"),
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
