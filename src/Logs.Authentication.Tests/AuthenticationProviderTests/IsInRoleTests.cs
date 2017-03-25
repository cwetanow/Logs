using Logs.Authentication.Managers;
using Logs.Models;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace Logs.Authentication.Tests.AuthenticationProviderTests
{
    [TestFixture]
    public class IsInRoleTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "user")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "admin")]
        public void TestIsInRole_ShouldCallUserManagerIsInRole(string userId, string role)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.IsInRole(userId, role);

            // Assert
            mockedUserManager.Verify(m => m.IsInRoleAsync(userId, role), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "user", true)]
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "user", false)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "admin", true)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "admin", false)]
        public void TestIsInRole_ShouldReturnCorrectly(string userId, string role, bool isInRole)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.IsInRoleAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(isInRole);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            var result = provider.IsInRole(userId, role);

            // Assert
            Assert.AreEqual(isInRole, result);
        }

        [TestCase("user")]
        [TestCase("user")]
        [TestCase("admin")]
        [TestCase("admin")]
        public void TestIsInRole_UserIdIsNull_ShouldReturnFalse(string role)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            var result = provider.IsInRole(null, role);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
