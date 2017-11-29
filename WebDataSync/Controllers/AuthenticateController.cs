using MobileData;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebDataSync.Security;

namespace WebDataSync.Controllers
{
    [ApiAuthenticationFilter]
    [RoutePrefix("api/Authenticate")]
    public class AuthenticateController : ApiController
    {
        public AuthenticateController()
        {
        }

        [HttpGet]
        public HttpResponseMessage Authenticate()
        {
            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var userId = basicAuthenticationIdentity.UserId;
                    return GetAuthToken(userId);
                }
            }
            return null;
        }

        private HttpResponseMessage GetAuthToken(int userId)
        {
            TokenServices service = new TokenServices();

            var token = service.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add(MobileCommon.WebToken, token.AuthToken.ToString());
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
    }
}