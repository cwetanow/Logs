using System.Web;
using Logs.Authentication.Contracts;
using Logs.Authentication.Managers;
using Logs.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Logs.Authentication
{
    public class HttpContextAuthenticationProvider : IAuthenticationProvider
    {
        protected ApplicationSignInManager SignInManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            }
        }
        protected ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return HttpContext.Current.User.Identity.GetUserId();
            }
        }

        public IdentityResult RegisterAndLoginUser(User user, string password, bool isPersistent, bool rememberBrowser)
        {
            var result = this.UserManager.Create(user, password);

            if (result.Succeeded)
            {
                this.SignInManager.SignIn(user, isPersistent, rememberBrowser);
            }

            return result;
        }

        public SignInStatus SignInWithPassword(string email, string password, bool rememberMe, bool shouldLockout)
        {
            return this.SignInManager.PasswordSignIn(email, password, rememberMe, shouldLockout);
        }

        public void SignOut()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
