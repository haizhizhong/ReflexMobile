using MobileData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/Companies")]
    public class CompaniesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            string sql = @"select AutoID, Company_Name, CompanyServerName, TreasuryDBName from COMPANIES";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.WebConnection);

            List<Company> list = new List<Company>();
            table.Select().ToList().ForEach(r => list.Add(new Company
            {
                MatchId = (int)r["AutoID"],
                CompanyName = (string)r["Company_Name"],
                Server = (string)r["CompanyServerName"],
                DataBase = (string)r["TreasuryDBName"],
                IsDefault = false,
                LastSyncTime = DateTime.MinValue
            }));

            return Ok(list);
        }
    }
}
