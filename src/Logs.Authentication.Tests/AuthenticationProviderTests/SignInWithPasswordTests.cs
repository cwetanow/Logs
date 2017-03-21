using Logs.Authentication.Managers;
using Logs.Models;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;

namespace Logs.Authentication.Tests.AuthenticationProviderTests
{
    [TestFixture]
    public class SignInWithPasswordTests
    {
        [TestCase("email@email.com", "qwerty123", true, false)]
        public void TestSignInWithPassword_ShouldCallSignInManagerPasswordSignIn(string email, string password,
            bool remember, bool shouldLockout)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationSignInManager>()).Returns(mockedSignInManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.SignInWithPassword(email, password, remember, shouldLockout);

            // Assert
            mockedSignInManager.Verify(m => m.PasswordSignInAsync(email, password, remember, shouldLockout));
        }

        [TestCase("email@email.com", "qwerty123", true, false, SignInStatus.Success)]
        [TestCase("email@email.com", "qwerty123", true, false, SignInStatus.Failure)]
        [TestCase("email@email.com", "qwerty123", true, false, SignInStatus.RequiresVerification)]
        [TestCase("email@email.com", "qwerty123", true, false, SignInStatus.LockedOut)]
        public void TestSignInWithPassword_ShouldReturnCorrectly(string email, string password,
            bool remember, bool shouldLockout, SignInStatus signInStatus)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);
            mockedSignInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                It.IsAny<bool>())).ReturnsAsync(signInStatus);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationSignInManager>()).Returns(mockedSignInManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            var result = provider.SignInWithPassword(email, password, remember, shouldLockout);

            // Assert
            Assert.AreEqual(signInStatus, result);
        }
    }
}
