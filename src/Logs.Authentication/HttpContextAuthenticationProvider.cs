using System;
using System.Web;
using Logs.Authentication.Contracts;
using Logs.Authentication.Managers;
using Logs.Models;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Logs.Authentication
{
    public class HttpContextAuthenticationProvider : IAuthenticationProvider
    {
        private const int HoursBan = 24 * 365;

        private readonly IDateTimeProvider dateTimeProvider;

        public HttpContextAuthenticationProvider(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

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

        public string CurrentUserUsername
        {
            get
            {
                return HttpContext.Current.User.Identity.GetUserName();
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

        public bool IsInRole(string userId, string roleName)
        {
            return this.UserManager.IsInRole(userId, roleName);
        }

        public IdentityResult AddToRole(string userId, string roleName)
        {
            return this.UserManager.AddToRole(userId, roleName);
        }

        public IdentityResult RemoveFromRole(string userId, string roleName)
        {
            return this.UserManager.RemoveFromRole(userId, roleName);
        }

        public void BanUser(string userId)
        {
            var user = this.UserManager.FindById(userId);
            user.LockoutEndDateUtc = this.dateTimeProvider.GetTimeFromCurrentTime(HoursBan, 0, 0);

            this.UserManager.Update(user);
        }

        public void UnbanUser(string userId)
        {
            var user = this.UserManager.FindById(userId);
            user.LockoutEndDateUtc = null;

            this.UserManager.Update(user);
        }
    }
}
