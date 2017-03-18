﻿using System.Security.Principal;
using System.Web;
using Logs.Providers.Contracts;
using Microsoft.Owin;

namespace Logs.Providers
{
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContext CurrentHttpContext
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public IOwinContext CurrentOwinContext
        {
            get
            {
                return this.CurrentHttpContext.GetOwinContext();
            }
        }

        public IIdentity CurrentIdentity
        {
            get
            {
                return this.CurrentHttpContext.User.Identity;
            }
        }
    }
}
