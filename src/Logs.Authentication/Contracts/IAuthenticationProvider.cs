using Logs.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Logs.Authentication.Contracts
{
    public interface IAuthenticationProvider
    {
        bool IsAuthenticated { get; }

        IdentityResult CreateUser(User user, string password);

        void SignIn(User user, bool isPersistent, bool rememberBrowser);

        SignInStatus SignInWithPassword(string email, string password, bool rememberMe, bool shouldLockout);

        void SignOut();
    }
}