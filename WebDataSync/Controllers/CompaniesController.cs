using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using static MobileData.Equipment;

namespace WebDataSync.Controllers
{
    public enum EnumDayInWeek
    {
        Monday = 'M',
        Tuesday = 'T',
        Wednesday = 'W',
        Thursday = 'H',
        Friday = 'F',
        Saturday = 'S',
        Sunday = 'U'
    };

    [RoutePrefix("api/Companies")]
    public class CompaniesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                string sql = $"select * from COMPANIES";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.WebConnection);

                List<Company> list = new List<Company>();
                table.Select().ToList().ForEach(r => list.Add(new Company
                {
                    MatchId = (int)r["AutoID"],
                    CompanyName = (string)r["Company_Name"],
                    ShortName = ConvertEx.StrOrEmpty(r["companyShortName"]),
                    Active = (bool)r["Active"],
                }));

                foreach (var com in list)
                {
                    sql = @"select * from Company";
                    table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(com.MatchId));
                    com.CompanyAddress1 = Convert.ToString(table.Rows[0]["ADD1"]);
                    com.CompanyAddress2 = Convert.ToString(table.Rows[0]["ADD2"]);
                    com.CompanyAddress3 = Convert.ToString(table.Rows[0]["ADD3"]);
                    com.CompanyCity = Convert.ToString(table.Rows[0]["City"]);
                    com.CompanyState = Convert.ToString(table.Rows[0]["State"]);
                    com.CompanyZip = Convert.ToString(table.Rows[0]["Zip"]);
                    com.CompanyPhone = Convert.ToString(table.Rows[0]["Phone"]);
                    com.CompanyFax = Convert.ToString(table.Rows[0]["Fax"]);
                    com.CompanyEmail = Convert.ToString(table.Rows[0]["Email"]);
                    com.CompanyWeb = Convert.ToString(table.Rows[0]["WebPage"]);

                    sql = "select isnull(case when rtrim(week_start) = '' then null else week_start end, 'U') as week_start from hr_cntl";
                    EnumDayInWeek day =  ConvertEx.CharToEnum<EnumDayInWeek>(SqlCommon.ExecuteScalar(sql, WebCommon.GetTRConnectionAsync(com.MatchId)));
                    com.WeekStart = ConvertEx.StringToEnum<DayOfWeek>(Enum.GetName(typeof(EnumDayInWeek), day));

                    sql = @"select use_cat_class from fa_setup";
                    table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(com.MatchId));
                    com.EquipRateGroupType = (EnumGroupType)Convert.ToChar(table.Rows[0]["use_cat_class"]);

                    sql = @"select lv1_active_gc, lv1_gencon_desc, lv2_active_gc, lv2_gencon_desc, lv3_active_gc, lv3_gencon_desc, lv4_active_gc, lv4_gencon_desc from proj_cntl";
                    table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.GetTRConnectionAsync(com.MatchId));
                    com.MaxLevelCode = (table.Rows[0]["lv4_active_gc"] != DBNull.Value ? 4 :
                                       (table.Rows[0]["lv3_active_gc"] != DBNull.Value ? 3 :
                                       (table.Rows[0]["lv2_active_gc"] != DBNull.Value ? 2 :
                                       (table.Rows[0]["lv1_active_gc"] != DBNull.Value ? 1 : 0))));
                    com.Level1CodeDesc = Convert.ToString(table.Rows[0]["lv1_gencon_desc"]);
                    com.Level2CodeDesc = Convert.ToString(table.Rows[0]["lv2_gencon_desc"]);
                    com.Level3CodeDesc = Convert.ToString(table.Rows[0]["lv3_gencon_desc"]);
                    com.Level4CodeDesc = Convert.ToString(table.Rows[0]["lv4_gencon_desc"]);
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }

        //[HttpGet]
        //public IHttpActionResult RefreshLastSyncTime(int companyId, string clientMac)
        //{
        //    try
        //    {
        //        using (SqlConnection sqlcon = new SqlConnection(WebCommon.WebConnection))
        //        {
        //            sqlcon.Open();

        //            string sSQL = @"WS_FLEM_MobileSync_PostPut";
        //            SqlCommand cmd = new SqlCommand(sSQL, sqlcon);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add(new SqlParameter("@CompanyId", companyId));
        //            cmd.Parameters.Add(new SqlParameter("@ClientMac", clientMac));
        //            cmd.ExecuteNonQuery();

        //            return Ok();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        SqlCommon.ReportInfo(e.Message);
        //        return BadRequest(e.Message);
        //    }
        //}
    }
}
