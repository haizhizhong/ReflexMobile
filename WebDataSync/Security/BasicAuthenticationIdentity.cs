using System.Security.Principal;

namespace WebDataSync.Security
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public string UserName { get; set; }
        public int UserId { get; set; }

        public BasicAuthenticationIdentity(string userName)
            : base(userName)
        {
            UserName = userName;
        }
    }
}