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
    [RoutePrefix("api/EquipmentBillRates")]
    public class EquipmentBillRatesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select isnull(u.TimeCode, 'U') BillCycle, m.Bill_Out_Rate, m.eqi_num, m.IS_Default " +
                $"from FA_RatSchedule_Eqi m join unit_time_measurement u on m.uom_id=u.Id";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<EquipmentBillRate> list = new List<EquipmentBillRate>();
                table.Select().ToList().ForEach(r => list.Add(new EquipmentBillRate
                {
                    CompanyId = companyId,
                    EqpNum = $"{r["eqi_num"]}",
                    BillCycle = (EnumBillCycle)(Convert.ToChar(r["BillCycle"])),
                    BillRate = (decimal)r["Bill_Out_Rate"],
                    IsDefault = (bool)r["IS_Default"]
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
