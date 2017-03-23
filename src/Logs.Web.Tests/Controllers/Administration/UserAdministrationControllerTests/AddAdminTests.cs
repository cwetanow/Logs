using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.Administration.UserAdministrationControllerTests
{
    [TestFixture]
    public class AddAdminTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 1)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 2)]
        public void TestAddAdmin_ShouldCallAuthProviderAddToRole(string userId, int page)
        {
            // Arrange
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();

            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.AddAdmin(userId, page);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.AddToRole(userId, Common.Constants.AdministratorRoleName), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 1)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 2)]
        public void TestAddAdmin_ShouldReturnRedirectToActionWithCorrectPage(string userId, int page)
        {
            // Arrange
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();

            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.AddAdmin(userId, page))
                .ShouldRedirectTo(c => c.Index(page, It.IsAny<int>()));
        }
    }
}
