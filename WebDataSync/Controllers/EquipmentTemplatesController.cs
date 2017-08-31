using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/EquipmentTemplates")]
    public class EquipmentTemplatesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = "select cece_id, cer_id, eqi_id, start_date, end_date from costing_equipment_class_equip";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<EquipmentTemplate> list = new List<EquipmentTemplate>();
            table.Select().ToList().ForEach(r => list.Add(new EquipmentTemplate
            {
                MatchId = r.Field<int>("cece_id"),
                CompanyId = companyId,
                EquipId = r.Field<int>("eqi_id"),
                ProjectEquipClassId = r.Field<int>("cer_id"),
                StartDate = r.Field<DateTime?>("start_date"),
                EndDate = r.Field<DateTime?>("end_date"),
            }));

            return Ok(list);
        }
    }
}
