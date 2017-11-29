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
    [RoutePrefix("api/EquipmentTemplates")]
    public class EquipmentTemplatesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = "select cece_id, c.pri_id, eqi_num, c.eqi_class, start_date, end_date from costing_equipment_class_equip t " +
                    "join Equip_ID e on t.eqi_id = e.eqi_id " +
                    "join costing_equipment_class c on t.cer_id = c.cer_id";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<EquipmentTemplate> list = new List<EquipmentTemplate>();
                table.Select().ToList().ForEach(r => list.Add(new EquipmentTemplate
                {
                    MatchId = r.Field<int>("cece_id"),
                    CompanyId = companyId,
                    ProjectId = r.Field<int>("pri_id"),
                    EqpNum = r.Field<string>("eqi_num"),
                    EquipClassCode = r.Field<string>("eqi_class"),
                    StartDate = r.Field<DateTime?>("start_date"),
                    EndDate = r.Field<DateTime?>("end_date"),
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
