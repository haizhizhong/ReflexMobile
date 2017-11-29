using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebDataSync.Security;

namespace WebDataSync.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/ChangeOrders")]
    public class ChangeOrdersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int companyId)
        {
            try
            {
                string sql = @"select h.ID [EstId], p.pri_id, h.CO_Num, Substring(h.co_desc,1,50) [COName], case when h.CO_Conv_Method = 'M' then 'Imbedded' else 'Separate' end [ConvType]
                from EST_Header h
                join proj_header p on p.pri_id = h.CO_Ref_Pri_ID
                left outer join proj_header co on co.est_id = h.id
                where h.IsChangeOrder = 1 and h.Est_Status = 'C' and isnull(co.pri_status,'') not in ('X', 'L') and isnull(p.pri_status,'') not in ('X', 'L')
                order by p.pri_id, h.CO_Num";

                DataTable table = ReflexCommon.SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));

                List<ChangeOrder> list = new List<ChangeOrder>();
                table.Select().ToList().ForEach(r => list.Add(new ChangeOrder
                {
                    CompanyId = companyId,
                    ProjectId = r.Field<int>("pri_id"),
                    EstimateId = r.Field<int>("EstId"),
                    ChangeOrderNum = r.Field<int?>("CO_Num"),
                    ChangeOrderName = r.Field<string>("COName")
                }));

                return Ok(list);
            }
            catch (Exception e)
            {
                ReflexCommon.SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
