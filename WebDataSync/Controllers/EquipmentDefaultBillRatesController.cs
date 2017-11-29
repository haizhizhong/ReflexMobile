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
    [RoutePrefix("api/EquipmentDefaultBillRates")]
    public class EquipmentDefaultBillRatesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select isnull(u.TimeCode, 'U') BillCycle, m.Bill_Out_Rate, Rate_Type, m.IS_Default from FA_RatSchedule_Setup m " +
                    $"join unit_time_measurement u on m.uom_id = u.Id";

                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<EquipmentDefaultBillRate> list = new List<EquipmentDefaultBillRate>();
                table.Select().ToList().ForEach(r =>
                {
                    list.Add(new EquipmentDefaultBillRate
                    {
                        CompanyId = companyId,
                        GroupType = (EnumGroupType)(Convert.ToChar(r["Rate_Type"])),
                        BillCycle = (EnumBillCycle)(Convert.ToChar(r["BillCycle"])),
                        BillRate = (decimal)r["Bill_Out_Rate"],
                        IsDefault = (bool)r["IS_Default"]
                    });
                });

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
