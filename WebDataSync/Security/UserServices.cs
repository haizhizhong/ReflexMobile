using MobileData;
using ReflexCommon;

namespace WebDataSync.Security
{
    public interface IUserServices
    {
        int? Authenticate(string userName);
    }

    public class UserServices : IUserServices
    {
        public UserServices()
        {
        }

        public int? Authenticate(string userName)
        {
            string sql = $"select id from Contact where Windows_Login='{userName}'";
            return (int?)SqlCommon.ExecuteScalar(sql, WebCommon.WebConnection);
        }
    }
}