using ReflexCommon;
using System;
using System.IO;
using System.Web;
using System.Web.Http;

namespace WebDataSync
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //string log = $"{HttpContext.Current.Server.MapPath("..")}\\log.txt";            // clear log file whenever restart
            //File.WriteAllText(log, String.Empty);

            SqlCommon.ReportMessage += ReportError;
        }

        private void ReportError(string msg)
        {
            string log = $"{HttpContext.Current.Server.MapPath("..")}\\log.txt";
            File.AppendAllText(log, $"{DateTime.Now}:  {msg}\n");
        }
    }
}
