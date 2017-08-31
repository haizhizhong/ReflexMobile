using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/LemLogHeader")]
    public class LemLogHeaderController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId, DateTime lastUpdateTime)
        {
            string sql = $"select id, LogDate, LogStatus, pri_ID from WS_PCDL_LogHeader";       // todo: lastUpdateTime 
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

            List<LemLogHeader> list = new List<LemLogHeader>();
            table.Select().ToList().ForEach(r => list.Add(new LemLogHeader
            {
                MatchId = r.Field<int>("pri_id"),
                CompanyId = companyId,
                LogDate = r.Field<DateTime>("LogDate"),
                LogStatus = (EnumLogStatus)Enum.Parse(typeof(EnumLogStatus), $"{r["LogStatus"]}"),
                ProjectId = r.Field<int>("ProjectId"),
            }));

            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] LemLogHeader item)
        {
            string sql = $"insert WS_PCDL_LogHeader(LogDate, LogStatus, pri_ID) values('{item.LogDate}', '{item.LogStatus}', {item.ProjectId});" +
                $" Select CAST(SCOPE_IDENTITY() AS INT);";
            //            int matchId = (int)Common.ExecuteScalar(sql, WebCommon.GetTRConnectionAsync(item.CompanyId));

            int matchId = 999;
            return Ok(matchId);
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] LemLogHeader item)
        {
            string sql = $"insert WS_PCDL_LogHeader(LogDate, LogStatus, pri_ID) values('{item.LogDate}', '{item.LogStatus}', {item.ProjectId});" +
                $" Select CAST(SCOPE_IDENTITY() AS INT);";
            //            int matchId = (int)Common.ExecuteScalar(sql, WebCommon.GetTRConnectionAsync(item.CompanyId));

            return Ok();
        }
    }
}
