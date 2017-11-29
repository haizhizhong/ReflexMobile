using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebDataSync.Security;
using static MobileData.Equipment;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/Equipments")]
    public class EquipmentsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = "select eqi_num, eqi_code, eqi_desc1, eqi_class, eqi_cat, isnull(own_type,'U') own_type from Equip_ID";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<Equipment> list = new List<Equipment>();
                table.Select().ToList().ForEach(r => list.Add(new Equipment
                {
                    EqpNum = (string)r["eqi_num"],
                    CompanyId = companyId,
                    AssetCode = (string)r["eqi_code"],
                    Desc = (string)r["eqi_desc1"],
                    ClassCode = (string)r["eqi_class"],
                    CategoryCode = (string)r["eqi_cat"],
                    OwnerType = ConvertEx.CharToEnum<EnumOwnerType>(r["own_type"])
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
