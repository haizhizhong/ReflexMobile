using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/EquipmentClasses")]
    public class EquipmentClassesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = "select facl_code, facl_desc from fa_class";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<EquipmentClass> list = new List<EquipmentClass>();
            table.Select().ToList().ForEach(r => list.Add(new EquipmentClass
            {
                CompanyId = companyId,
                Code = r.Field<string>("facl_code"),
                Desc = r.Field<string>("facl_desc"),
            }));

            return Ok(list);
        }
    }
}
