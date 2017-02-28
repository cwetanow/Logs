using System.Web;
using Logs.Authentication.Contracts;

namespace Logs.Authentication
{
    public class HttpContextAuthenticationProvider : IAuthenticationProvider
    {
        public bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }
    }
}
