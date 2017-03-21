using System.Web;
using System.Web.Hosting;
using Logs.Authentication.Managers;
using Logs.Authentication.Tests.AuthenticationProviderTests.Mocks;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Moq;
using NUnit.Framework;

namespace Logs.Authentication.Tests.AuthenticationProviderTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void TestSignInManager_ShouldCallHttpContextProviderGetUserManager()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            var provider = new MockedAuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.GetSignInManager();

            // Assert
            mockedHttpContextProvider.Verify(p => p.GetUserManager<ApplicationSignInManager>(), Times.Once);
        }

        [Test]
        public void TestUserManager_ShouldCallHttpContextProviderGetUserManager()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            var provider = new MockedAuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.GetUserManager();

            // Assert
            mockedHttpContextProvider.Verify(p => p.GetUserManager<ApplicationUserManager>(), Times.Once);
        }
    }
}
