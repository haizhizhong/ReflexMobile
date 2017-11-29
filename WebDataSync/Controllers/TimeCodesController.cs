using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebDataSync.Security;
using static MobileData.TimeCode;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/TimeCodes")]
    public class TimeCodesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = $"select w.Id, w.Description, w.ValueType, isnull(w.BillingRateType, 'Unknown')[BillingRateType], " +
                    $"w.InclInHoursThisWeek, w.Time_Code_ID_OT, w.Time_Code_ID_DT, e.comp_code[Component], ReportTypeColumn from WS_EMP_Time_Code w " +
                    $"join earn_code e on e.eg_code = w.eg_code and e.ec_code = w.ec_code";

                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<TimeCode> list = new List<TimeCode>();
                table.Select().ToList().ForEach(r => list.Add(new TimeCode
                {
                    MatchId = (int)r["Id"],
                    CompanyId = companyId,
                    Desc = $"{r["Description"]}",
                    ValueType = ConvertEx.StringToEnum<EnumValueType>(r["ValueType"]),
                    BillingType = ConvertEx.StringToEnum<EnumBillingRateType>(r["BillingRateType"]),
                    OvertimeId = r.Field<int?>("Time_Code_ID_OT"),
                    DoubleTimeId = r.Field<int?>("Time_Code_ID_DT"),
                    IncludedInWeekCalc = (bool)r["InclInHoursThisWeek"],
                    Component = ConvertEx.CharToEnum<EnumComponentType>(r["Component"]),
                    ReportTypeColumn = Convert.ToString(r["ReportTypeColumn"])
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
