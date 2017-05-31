using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Areas.Users.Controllers;
using Logs.Web.Areas.Users.Models;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.Users.NutritionControllerTests
{
    [TestFixture]
    public class DetailsTests
    {
        [Test]
        public void TestDetails_PassUsernameNull_ShouldReturnHttpNotFoundResult()
        {
            // Arrange
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Act
            var result = controller.Details(null);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void TestDetails_PassUsernameNull_ShouldNotCallUserServiceGetUserByUsername()
        {
            // Arrange
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Act
            controller.Details(null);

            // Assert
            mockedService.Verify(s => s.GetUserByUsername(It.IsAny<string>()), Times.Never);
        }

        [TestCase("username")]
        [TestCase("myUsername")]
        public void TestDetails_PassUsername_ShouldCallUserServiceGetUserByUsername(string username)
        {
            // Arrange
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedService.Verify(s => s.GetUserByUsername(username), Times.Once);
        }

        [TestCase("username")]
        [TestCase("myUsername")]
        public void TestDetails_ServiceReturnsNull_ShouldReturnHttpNotFoundResult(string username)
        {
            // Arrange
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Act
            var result = controller.Details(username);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [TestCase("username")]
        [TestCase("myUsername")]
        public void TestDetails_ServiceReturnsNull_ShouldNotCallFactoryCreateUserIdViewModel(string username)
        {
            // Arrange
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedFactory.Verify(f => f.CreateUserIdViewModel(It.IsAny<string>()), Times.Never);
        }

        [TestCase("username", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("myUsername", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDetails_ServiceReturnsUser_ShouldCallFactoryCreateUserIdViewModel(string username, string userId)
        {
            // Arrange
            var user = new User { Id = userId };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedFactory.Verify(f => f.CreateUserIdViewModel(userId), Times.Once);
        }

        [TestCase("username", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("myUsername", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDetails_ServiceReturnsUser_ShouldRenderCorrectViewWithModel(string username, string userId)
        {
            // Arrange
            var user = new User { Id = userId };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var model = new UserIdViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateUserIdViewModel(It.IsAny<string>())).Returns(model);

            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Details(username))
                .ShouldRenderDefaultView()
                .WithModel<UserIdViewModel>(model);
        }
    }
}
