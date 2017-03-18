﻿using System;
using System.Security.Principal;
using System.Web;
using Logs.Authentication.Contracts;
using Logs.Authentication.Managers;
using Logs.Models;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Logs.Authentication
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private const int HoursBan = 24 * 365;

        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IHttpContextProvider httpContextProvider;

        public AuthenticationProvider(IDateTimeProvider dateTimeProvider, IHttpContextProvider httpContextProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.httpContextProvider = httpContextProvider;
        }

        protected IOwinContext OwinContext
        {
            get
            {
                return this.httpContextProvider.CurrentHttpContext.GetOwinContext();

            }
        }

        protected IIdentity Identity
        {
            get
            {
                return this.httpContextProvider.CurrentHttpContext.User.Identity;
            }
        }

        protected ApplicationSignInManager SignInManager
        {
            get
            {
                return this.OwinContext.GetUserManager<ApplicationSignInManager>();
            }
        }
        protected ApplicationUserManager UserManager
        {
            get
            {
                return this.OwinContext.GetUserManager<ApplicationUserManager>();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.Identity.IsAuthenticated;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return this.Identity.GetUserId();
            }
        }

        public string CurrentUserUsername
        {
            get
            {
                return this.Identity.GetUserName();
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
            this.OwinContext.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
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
