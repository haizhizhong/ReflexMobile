using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace MobileData
{
    public class LoginUser      //Contact
    {
        public int Id;
        public int MatchId;
        public string LoginName;
        public string CodeVersion;

        public List<UserAccess> AccessList;
        public List<ProjectAccess> ProjectList;

        public static LoginUser CurrUser { get; set; }

        static List<LoginUser> _list;

        public static List<LoginUser> List
        {
            get
            {
                if (_list == null)
                {
                    DataTable table = MobileCommon.ExecuteDataAdapter($"select * from LoginUser");
                    _list = table.Select().Select(r => new LoginUser
                    {
                        Id = (int)r["Id"],
                        MatchId = (int)r["MatchId"],
                        LoginName = (string)r["LoginName"],
                        CodeVersion = Convert.ToString(r["CodeVersion"]),
                    }).ToList();
                }

                return _list;
            }
        }

        public static LoginUser GetUser(int userId)
        {
            var user = List.SingleOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.AccessList = GetUserAccess(user.Id);
                user.ProjectList = GetProjectAccess(user.Id);
            }

            return user;
        }

        public static int? ValidUser(string user)
        {
            string sql = $"select id from LoginUser where LoginName='{user}'";
            return (int?)MobileCommon.ExecuteScalar(sql);
        }

        public static List<UserAccess> GetUserAccess(int userId)
        {
            string sql = $"select * from UserAccess where UserId={userId}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<UserAccess> list = table.Select().Select(r => new UserAccess
            {
                UserId = (int)r["UserId"],
                CompanyId = (int)r["CompanyId"],
                UserName = (string)r["UserName"],
                Department = (string)r["Department"]
            }).ToList();

            return list;
        }

        public static List<ProjectAccess> GetProjectAccess(int userId)
        {
            string sql = $"select * from ProjectAccess where UserId ={userId}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            List<ProjectAccess> list = table.Select().Select( r=> new ProjectAccess
            {
                UserId = (int)r["UserId"],
                CompanyId = (int)r["CompanyId"],
                ProjectId = (int)r["ProjectId"],
            }).ToList();

            return list;
        }

        public string GetUserName()
        {
            return AccessList.Single(x => x.CompanyId == Company.CurrentId).UserName;
        }

        public static string MaxCodeVersion()
        {
            string maxCodeVersion = Convert.ToString(MobileCommon.ExecuteScalar("select max(CodeVersion) from LoginUser"));
            return maxCodeVersion;
        }

        public static void UpdateCodeVersion(string ver)
        {
            MobileCommon.ExecuteNonQuery($"Update LoginUser set CodeVersion='{ver}' where id={CurrUser.Id}");
            CurrUser.CodeVersion = ver;
        }

        public static string AddSqlUsers()
        {
            using (PrincipalContext domain = new PrincipalContext(ContextType.Domain))
            {
                List<string> badList = new List<string>();
                List.ForEach(x =>
                {
                    if (UserPrincipal.FindByIdentity(domain, IdentityType.SamAccountName, x.LoginName) != null)
                        DataManage.CheckAddSqlUser(x.LoginName);
                    else
                        badList.Add(x.LoginName);
                });

                if (badList.Count > 0)
                {
                    string names = "";
                    badList.ForEach(x => names += $", {x}");
                    return $"These Users are not in the Domain, cannot create SQL users for them: {names.Substring(2)}.";
                }
            }

            return null;
        }

        public static void Refresh()
        {
            _list = null;
        }
    }

    public class UserAccess
    {
        public int UserId;
        public int CompanyId;
        public string UserName;
        public string Department;
    }

    public class ProjectAccess
    {
        public int UserId;
        public int CompanyId;
        public int ProjectId;
    }
}
