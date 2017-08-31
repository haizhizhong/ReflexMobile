using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/LoginUsers")]
    public class LoginUsersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            string sql = @"select AutoID from COMPANIES";
            DataTable table = Common.ExecuteDataAdapter(sql, WebCommon.WebConnection);
            List<int> companyIdList = new List<int>();
            table.Select().ToList().ForEach(r => companyIdList.Add((int)r["AutoID"]));

            sql = @"select ID, Windows_Login, isnull(Password,'') Password from Contact where Windows_Login is not null and IsFieldManager='T'";    //todo: use IsFieldManager?
            table = Common.ExecuteDataAdapter(sql, WebCommon.WebConnection);

            List<LoginUser> list = new List<LoginUser>();
            table.Select().ToList().ForEach(r =>
            {
                int userId = r.Field<int>("ID");
                string userName = r.Field<string>("Windows_Login");
                string password = r.Field<string>("Password");

                List<int> userAsscessList = new List<int>();
                List<int> projectList = new List<int>();
                foreach (int companyId in companyIdList)
                {
                    sql = $"select CAST(COUNT(*) AS bit) from mluser where contactID={userId}";
                    if ((bool)Common.ExecuteScalar(sql, WebCommon.GetTRConnectionAsync(companyId)))
                    {
                        userAsscessList.Add(companyId);

                        //todo: pri_type='PGC' ??
                        sql = $"PC_ProjectSearch @username='{userName}', @pri_type='PGC', @include_co='B', @pri_id=null, @pri_id2=null, @pri_status=null, @non_closed=null, " +
                            $"@customer_id=null, @customer_id2=null, @pri_division=null, @proj_manager=null, @engineer=null, @architect=null, @field_forman=null, @proj_accountant=null, " +
                            $"@salesperson=null, @gen_contractor=null, @estimator=null, @customer_contact=null, @prc_code=null, @prcl_code=null, " +
                            $"@pri_whs=null, @customer_po=null, @est_completion=null, @geographic_area_id=null, @municipalities_id=null, " +
                            $"@communities_id=null, @land_use_id=null, @external_ref=null, @co_pri_id=null, @co_pri_id2=null, @proj_customer_type_id=null, " +
                            $"@field_manager=null, @proj_coordinator=null, @LandSubType=null, @RawLandHolding_Pri_ID=null, @pri_profit=null";
                        Common.ExecuteNonQuery(sql, WebCommon.GetTRConnectionAsync(companyId));

                        sql = $"select pri_id from working_proj_selected where username='{userName}'";
                        DataTable projectTable = Common.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(companyId));
                        projectTable.Select().ToList().ForEach(p => projectList.Add((int)p["pri_id"]));
                    }
                }

                list.Add(new LoginUser
                {
                    MatchId = userId,
                    UserName = userName,
                    Password = password,
                    CompanyList = userAsscessList,
                    ProjectList = projectList,
                });
            });

            return Ok(list);
        }
    }
}
