using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/ProjectEquipmentClasses")]
    public class ProjectEquipmentClassesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            string sql = $"select cer_id, pri_id, eqi_Class, isnull(sch_enabled, 0) Schedulable, cast(case UseEquipOverride when 'T' then 1 else 0 end as bit) as UseOverride, " +
                $"rate, isnull(TimeCode, 'U') BillCycle from costing_equipment_class m join unit_time_measurement u on m.UOM=u.Id";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<ProjectEquipmentClass> list = new List<ProjectEquipmentClass>();
            table.Select().ToList().ForEach(r => list.Add(new ProjectEquipmentClass
            {
                MatchId = r.Field<int>("cer_id"),
                CompanyId = companyId,
                ProjectId = r.Field<int>("pri_id"),
                ClassCode = r.Field<string>("eqi_Class"),
                Schedulable = r.Field<bool>("Schedulable"),
                UseOverride = r.Field<bool>("UseOverride"),
                BillRate = r.Field<decimal?>("rate"),
                BillCycle = (Equipment.EnumBillCycle)(r.Field<string>("BillCycle")[0]),
            }));

            return Ok(list);
        }
    }
}
