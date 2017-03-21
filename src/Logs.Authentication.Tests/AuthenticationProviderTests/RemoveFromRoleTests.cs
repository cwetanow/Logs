using Logs.Authentication.Managers;
using Logs.Models;
using Logs.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace Logs.Authentication.Tests.AuthenticationProviderTests
{
    [TestFixture]
    public class RemoveFromRoleTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "user")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "admin")]
        public void TestRemoveFromRole_ShouldCallUserManagerRemoveFromRole(string userId, string role)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.RemoveFromRole(userId, role);

            // Assert
            mockedUserManager.Verify(m => m.RemoveFromRoleAsync(userId, role), Times.Once);
        }
    }
}
