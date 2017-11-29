using MobileData;
using ReflexCommon;
using System;
using System.Linq;
using System.Data;

namespace WebDataSync.Security
{

    public class WebToken
    {
        public int UserId;
        public Guid AuthToken;
        public DateTime IssuedOn;
        public DateTime ExpiresOn;

        public void SqlInsertUpdate()
        {
            string sql = $"update MobileWebToken set AuthToken='{AuthToken}', IssuedOn='{IssuedOn}', ExpiresOn='{ExpiresOn}' where UserId={UserId}; " +
                         $"IF(@@ROWCOUNT=0) " +
                                $"insert MobileWebToken(UserId, AuthToken, IssuedOn, ExpiresOn) " +
                                $"values({UserId}, '{AuthToken}', '{IssuedOn}', '{ExpiresOn}');";
            SqlCommon.ExecuteNonQuery(sql, WebCommon.WebConnection);
        }

        public void SqlUpdate()
        {
            string sql = $"update MobileWebToken set ExpiresOn='{ExpiresOn}' where AuthToken='{AuthToken}'";
            SqlCommon.ExecuteNonQuery(sql, WebCommon.WebConnection);
        }

        public static WebToken GetByGuid(Guid guid)
        {
            string sql = $"select * from  MobileWebToken where AuthToken='{guid}' and ExpiresOn>getdate()";
            DataTable table = SqlCommon.ExecuteDataAdapter(sql, WebCommon.WebConnection);
            return table.Select().Select(r => new WebToken
            {
                UserId = (int)r["UserId"],
                AuthToken = (Guid)r["AuthToken"],
                IssuedOn = (DateTime)r["IssuedOn"],
                ExpiresOn = (DateTime)r["ExpiresOn"]
            }).SingleOrDefault();
        }

        public static void KillByGuid(Guid guid)
        {
            string sql = $"delete MobileWebToken where AuthToken='{guid}'";
            SqlCommon.ExecuteNonQuery(sql, WebCommon.WebConnection);
        }
    }
}