using System.Collections.Generic;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Logs.Web.Areas.Administration.Models;
using Moq;
using NUnit.Framework;
using PagedList;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.Administration.UserAdministrationControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void TestIndex_ShouldCallServiceGetUsers()
        {
            // Arrange
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();

            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Index();

            // Assert
            mockedUserService.Verify(s => s.GetUsers(), Times.Once);
        }

        [Test]
        public void TestIndex_ShouldCallAuthProviderIsInRoleTimesUsersCount()
        {
            // Arrange
            var users = new List<User> { new User(), new User() };

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUsers()).Returns(users);

            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthenticationProvider.Verify(p => p.IsInRole(It.IsAny<string>(), Common.Constants.AdministratorRoleName), Times.Exactly(users.Count));
        }

        [TestCase(1, 1)]
        [TestCase(1, 31)]
        [TestCase(41, 12)]
        [TestCase(7, 11)]
        [TestCase(11, 112)]
        public void TestIndex_ShouldReturnPagedListWithCorrectPage(int page, int count)
        {
            // Arrange
            var users = new List<User> { new User(), new User() };

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUsers()).Returns(users);

            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index(page, count))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<UserViewModel>>(m => Assert.AreEqual(page, m.PageNumber));
        }
    }
}
