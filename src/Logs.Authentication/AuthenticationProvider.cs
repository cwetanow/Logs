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
            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException(nameof(dateTimeProvider));
            }

            if (httpContextProvider == null)
            {
                throw new ArgumentNullException(nameof(httpContextProvider));
            }

            this.dateTimeProvider = dateTimeProvider;
            this.httpContextProvider = httpContextProvider;
        }

        protected ApplicationSignInManager SignInManager
        {
            get
            {
                return this.httpContextProvider.CurrentOwinContext.GetUserManager<ApplicationSignInManager>();
            }
        }
        protected ApplicationUserManager UserManager
        {
            get
            {
                return this.httpContextProvider.CurrentOwinContext.GetUserManager<ApplicationUserManager>();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.httpContextProvider.CurrentIdentity.IsAuthenticated;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return this.httpContextProvider.CurrentIdentity.GetUserId();
            }
        }

        public string CurrentUserUsername
        {
            get
            {
                return this.httpContextProvider.CurrentIdentity.GetUserName();
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
            this.httpContextProvider.CurrentOwinContext.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
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
