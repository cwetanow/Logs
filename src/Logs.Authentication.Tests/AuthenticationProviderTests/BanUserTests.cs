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
    public class BanUserTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestBanUser_ShouldCallUserManagerFindById(string userId)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var user = new User();

            var mockedUserStore = new Mock<IUserStore<User>>();
            mockedUserStore.Setup(s => s.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(user));

            var userManager = new ApplicationUserManager(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(userManager);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.BanUser(userId);

            // Assert
            mockedUserStore.Verify(s => s.FindByIdAsync(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestBanUser_ShouldCallDateTimeProviderGetTimeFromCurrentTime(string userId)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var user = new User();

            var mockedUserStore = new Mock<IUserStore<User>>();
            mockedUserStore.Setup(s => s.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(user));

            var userManager = new ApplicationUserManager(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(userManager);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.BanUser(userId);

            // Assert
            mockedDateTimeProvider.Verify(p => p.GetTimeFromCurrentTime(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestBanUser_ShouldSetUserLockoutEndDateCorrectly(string userId)
        {
            // Arrange
            var date = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(
                    p => p.GetTimeFromCurrentTime(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(date);

            var user = new User();

            var mockedUserStore = new Mock<IUserStore<User>>();
            mockedUserStore.Setup(s => s.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(user));

            var userManager = new ApplicationUserManager(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(userManager);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.BanUser(userId);

            // Assert
            Assert.AreEqual(date, user.LockoutEndDateUtc);
        }
    }
}
