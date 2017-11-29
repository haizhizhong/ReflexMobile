using MobileData;
using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebDataSync.Controllers
{
    [RoutePrefix("api/SystemInfo")]
    public class SystemInfoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string codeVer, string dbVer)
        {
            try
            {
                string sql = @"select MobileCodeVersion, MobileDbVersion, isnull(NumDayFLEMSheetAvail,0) KeepDays from system_ctrl";
                DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.WebConnection);

                SystemInfo info = table.Select().Select(r => new SystemInfo
                {
                    CodeVersion = Convert.ToString(r["MobileCodeVersion"]),
                    DataBaseVersion = Convert.ToString(r["MobileDbVersion"]),
                    KeepDays = ConvertEx.ToNullable<int>(r["KeepDays"]),
                    PatchScript = new List<string>()
                }).First();

                if (info.CodeVersion == codeVer && info.DataBaseVersion != dbVer)
                {
                    string fileName = HttpContext.Current.Server.MapPath("~/App_Data/UpdateScript.sql");
                    FileInfo fileInfo = new FileInfo(fileName);
                    string script = fileInfo.OpenText().ReadToEnd();
                    info.PatchScript.Add(script);
                }

                return Ok(info);
            }
            catch (Exception e)
            {
                SqlCommon.ReportInfo(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}