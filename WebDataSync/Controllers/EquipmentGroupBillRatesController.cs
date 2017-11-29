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
    [RoutePrefix("api/EquipmentGroupBillRates")]
    public class EquipmentGroupBillRatesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select isnull(u.TimeCode, 'U') BillCycle, Bill_Out_Rate, Code, Rate_Type, Is_Default " +
                $"from FA_RatSchedule_Class_Category m join unit_time_measurement u on m.uom_id = u.Id";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<EquipmentGroupBillRate> list = new List<EquipmentGroupBillRate>();
                table.Select().ToList().ForEach(r =>
                {
                    list.Add(new EquipmentGroupBillRate
                    {
                        CompanyId = companyId,
                        ProjectId = null,
                        GroupCode = $"{r["Code"]}",
                        GroupType = (EnumGroupType)(Convert.ToChar(r["Rate_Type"])),
                        BillCycle = (EnumBillCycle)(Convert.ToChar(r["BillCycle"])),
                        BillRate = (decimal)r["Bill_Out_Rate"]
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
