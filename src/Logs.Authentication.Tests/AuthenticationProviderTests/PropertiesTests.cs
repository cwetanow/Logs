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
        public void TestSignInManager_ShouldCallHttpContextProviderCurrentOwinContext()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedOwinContext = new Mock<IOwinContext>();

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentOwinContext).Returns(mockedOwinContext.Object);

            var provider = new MockedAuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.GetSignInManager();

            // Assert
            mockedHttpContextProvider.Verify(p => p.CurrentOwinContext, Times.Once);
        }

        [Test]
        public void TestUserManager_ShouldCallHttpContextProviderCurrentOwinContext()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedOwinContext = new Mock<IOwinContext>();

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentOwinContext).Returns(mockedOwinContext.Object);

            var provider = new MockedAuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.GetUserManager();

            // Assert
            mockedHttpContextProvider.Verify(p => p.CurrentOwinContext, Times.Once);
        }
    }
}
