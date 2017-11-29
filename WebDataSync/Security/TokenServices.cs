using System;
using System.Configuration;

namespace WebDataSync.Security
{
    public interface ITokenServices
    {
        WebToken GenerateToken(int userId);

        bool ValidateToken(Guid tokenId);

        bool Kill(Guid tokenId);
    }

    public class TokenServices : ITokenServices
    {
        public TokenServices()
        {
        }

        public WebToken GenerateToken(int userId)
        {
            Guid guid = Guid.NewGuid();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));

            var token = new WebToken
            {
                UserId = userId,
                AuthToken = guid,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };
            token.SqlInsertUpdate();

            return token;
        }

        public bool ValidateToken(Guid tokenId)
        {
            var token = WebToken.GetByGuid(tokenId);

            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                token.ExpiresOn = token.ExpiresOn.AddSeconds( Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                token.SqlUpdate();
                return true;
            }

            return false;
        }

        public bool Kill(Guid tokenId)
        {
            WebToken.KillByGuid(tokenId);
            return true;
        }
    }
}