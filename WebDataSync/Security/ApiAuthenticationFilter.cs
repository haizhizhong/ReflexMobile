﻿using System.Threading;
using System.Web.Http.Controllers;

namespace WebDataSync.Security
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        public ApiAuthenticationFilter()
        {
        }

        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        protected override bool OnAuthorizeUser(string username, HttpActionContext actionContext)
        {
            IUserServices provider = new UserServices();
            var userId = provider.Authenticate(username);
            if (userId != null)
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                    basicAuthenticationIdentity.UserId = userId.Value;
                return true;
            }
            return false;
        }
    }
}