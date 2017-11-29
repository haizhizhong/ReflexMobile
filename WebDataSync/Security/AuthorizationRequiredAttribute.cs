using MobileData;
using ReflexCommon;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebDataSync.Security
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (filterContext.Request.Headers.Contains(MobileCommon.WebToken))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(MobileCommon.WebToken).First();

                // Validate Token
                ITokenServices provider = new TokenServices();
                if (provider != null && !provider.ValidateToken(new Guid(tokenValue)))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                    filterContext.Response = responseMessage;
                }
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}