using MobileData;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebDataSync
{
    public class WebCommon
    {
        static Dictionary<int, string> _trList = null;

        private const string userName = "hmsqlsa";
        private const string password = "hmsqlsa";

        private static object myLock = new object();

        public static string WebConnection
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; }
        }

        public static string GetTRConnectionAsync(int companyId)
        {
            lock (myLock)
            {
                if (_trList == null)
                {
                    string sql = @"select AutoID, Company_Name, CompanyServerName, TreasuryDBName from COMPANIES";
                    Common.MobileDB = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                    DataTable table = Common.ExecuteDataAdapter(sql);

                    _trList = new Dictionary<int, string>();
                    table.Select().ToList().ForEach(r =>
                    {
                        string tr = $"Data Source={r["CompanyServerName"]};Initial Catalog={r["TreasuryDBName"]};Persist Security Info=True;User ID={userName};Password={password}";
                        _trList.Add((int)r["AutoID"], tr);
                    });
                }
            }

            return _trList[companyId];
        }
    }
}