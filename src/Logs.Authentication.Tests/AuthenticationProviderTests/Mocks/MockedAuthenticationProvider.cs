using System.Security.Principal;
using Logs.Authentication.Managers;
using Logs.Providers.Contracts;
using Microsoft.Owin;

namespace Logs.Authentication.Tests.AuthenticationProviderTests.Mocks
{
    public class MockedAuthenticationProvider : AuthenticationProvider
    {
        public MockedAuthenticationProvider(IDateTimeProvider dateTimeProvider, IHttpContextProvider httpContextProvider)
            : base(dateTimeProvider, httpContextProvider)
        {
        }

        public IOwinContext GetOwinContext()
        {
            return this.OwinContext;
        }

        public IIdentity GetIdentity()
        {
            return this.Identity;
        }

        public ApplicationSignInManager GetSignInManager()
        {
            return this.SignInManager;
        }

        public ApplicationUserManager GetUserManager()
        {
            return this.UserManager;
        }
    }
}
