using Logs.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Logs.Authentication.Contracts
{
    public interface IAuthenticationProvider
    {
        bool IsAuthenticated { get; }

        string CurrentUserId { get; }

        IdentityResult RegisterAndLoginUser(User user, string password, bool isPersistent, bool rememberBrowser);

        SignInStatus SignInWithPassword(string email, string password, bool rememberMe, bool shouldLockout);

        void SignOut();
    }
}