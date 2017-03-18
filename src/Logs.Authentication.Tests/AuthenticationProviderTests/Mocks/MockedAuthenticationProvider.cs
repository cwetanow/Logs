using Logs.Authentication.Managers;
using Logs.Providers.Contracts;

namespace Logs.Authentication.Tests.AuthenticationProviderTests.Mocks
{
    public class MockedAuthenticationProvider : AuthenticationProvider
    {
        public MockedAuthenticationProvider(IDateTimeProvider dateTimeProvider, IHttpContextProvider httpContextProvider)
            : base(dateTimeProvider, httpContextProvider)
        {
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
