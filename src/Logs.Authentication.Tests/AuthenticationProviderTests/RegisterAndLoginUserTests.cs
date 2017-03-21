using Logs.Authentication.Managers;
using Logs.Models;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;

namespace Logs.Authentication.Tests.AuthenticationProviderTests
{
    [TestFixture]
    public class RegisterAndLoginUserTests
    {
        [TestCase("password", true, true)]
        public void TestRegisterAndLoginUser_ShouldCallUserManagerCreate(string password, bool isPersistent, bool rememberBrowser)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(new IdentityResult());

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            var user = new User();

            // Act
            provider.RegisterAndLoginUser(user, password, isPersistent, rememberBrowser);

            // Assert
            mockedUserManager.Verify(m => m.CreateAsync(user, password), Times.Once);
        }

        [TestCase("password", true, true)]
        public void TestRegisterAndLoginUser_ReturnsSuccess_ShouldCallSignInManagerSignIn(string password, bool isPersistent, bool rememberBrowser)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationSignInManager>()).Returns(mockedSignInManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            var user = new User();

            // Act
            provider.RegisterAndLoginUser(user, password, isPersistent, rememberBrowser);

            // Assert
            mockedSignInManager.Verify(s => s.SignInAsync(user, isPersistent, rememberBrowser));
        }

        [TestCase("password", true, true)]
        public void TestRegisterAndLoginUser_ShouldReturnCorrectly(string password, bool isPersistent, bool rememberBrowser)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var result = new IdentityResult();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(result);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            var user = new User();

            // Act
            var actualResult = provider.RegisterAndLoginUser(user, password, isPersistent, rememberBrowser);

            // Assert
            Assert.AreSame(result, actualResult);
        }
    }
}
