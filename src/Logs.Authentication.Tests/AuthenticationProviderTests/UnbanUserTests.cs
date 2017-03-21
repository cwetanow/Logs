using System;
using System.Threading.Tasks;
using Logs.Authentication.Managers;
using Logs.Authentication.Tests.AuthenticationProviderTests.Mocks;
using Logs.Models;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace Logs.Authentication.Tests.AuthenticationProviderTests
{
    [TestFixture]
    public class UnbanUserTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnbanUser_ShouldCallUserManagerFindById(string userId)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var user = new User();

            var mockedUserStore = new Mock<IUserStore<User>>();
            mockedUserStore.Setup(s => s.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(user));

            var userManager = new ApplicationUserManager(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(userManager);

            var provider = new MockedAuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.UnbanUser(userId);

            // Assert
            mockedUserStore.Verify(s => s.FindByIdAsync(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnbanUser_ShouldSetUserLockoutEndDateNull(string userId)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var user = new User { LockoutEndDateUtc = new DateTime() };

            var mockedUserStore = new Mock<IUserStore<User>>();
            mockedUserStore.Setup(s => s.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(user));

            var userManager = new ApplicationUserManager(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(userManager);

            var provider = new MockedAuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.UnbanUser(userId);

            // Assert
            Assert.IsNull(user.LockoutEndDateUtc);
        }
    }
}
