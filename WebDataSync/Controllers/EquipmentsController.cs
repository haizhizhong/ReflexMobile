using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/Equipments")]
    public class EquipmentsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = "select eqi_num, eqi_code, eqi_desc1, eqi_class from Equip_ID";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<Equipment> list = new List<Equipment>();
            table.Select().ToList().ForEach(r => list.Add(new Equipment
            {
                EqpNum = (string)r["eqi_num"],
                CompanyId = companyId,
                AssetCode = (string)r["eqi_code"],
                Desc = (string)r["eqi_desc1"],
                ClassCode = (string)r["eqi_class"],
                EmpNum = -1,
            }));

            return Ok(list);
        }
    }
}
