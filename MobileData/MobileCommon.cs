using HMConnection;
using ReflexCommon;
using System.Data;
using System.Deployment.Application;
using System.Linq;
using System.Net.NetworkInformation;

namespace MobileData
{
    public class MobileCommon
    {
        public static string MobileDB { get; set; }

        public static string ServerName { get; set; }
        public static string DatabaseName { get; set; }

        public static string WebToken = "WebToken";

        public static HMCon HMCon { get; set; }

        public static string MachineMac
        {
            get
            {
                var mac = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.OperationalStatus == OperationalStatus.Up)
                    .Select(x => x.GetPhysicalAddress().ToString()).FirstOrDefault();
                return mac;
            }
        }

        public static string CurrentCodeVersion
        {
            get
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                else
                {
                    return LoginUser.CurrUser?.CodeVersion ?? LoginUser.MaxCodeVersion();
                }
            }
        }

        public static DataTable ExecuteDataAdapter(string sql)
        {
            return SqlCommon.ExecuteDataAdapter(sql, MobileDB);
        }

        public static bool ExecuteNonQuery(string sql)
        {
            return SqlCommon.ExecuteNonQuery(sql, MobileDB);
        }

        public static object ExecuteScalar(string sql)
        {
            return SqlCommon.ExecuteScalar(sql, MobileDB);
        }
    }
}
