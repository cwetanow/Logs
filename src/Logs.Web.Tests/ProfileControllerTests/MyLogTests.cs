using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.ProfileControllerTests
{
    [TestFixture]
    public class MyLogTests
    {
        [Test]
        public void TestMyLog_ShouldCallProviderCurrentUserId()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(new User());

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            controller.MyLog();

            // Assert
            mockedProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestMyLog_ShouldCallServiceGetUserById(string userId)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(new User());

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            controller.MyLog();

            // Assert
            mockedService.Verify(s => s.GetUserById(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestMyLog_UserLogIsNull_ShouldReturnRedirectToActionNoLog(string userId)
        {
            // Arrange
            var expectedRoute = "NoLog";

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(new User());

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            var result = controller.MyLog();

            // Assert
            Assert.AreEqual(expectedRoute, result.RouteValues["action"]);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestMyLog_UserHasLog_ShouldReturnRedirectToActionLogsControllerDetailsCorrectly(string userId)
        {
            // Arrange
            var expectedAction = "Details";

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var log = new TrainingLog();
            var user = new User { Log = log };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            var result = controller.MyLog();

            // Assert
            Assert.AreEqual(expectedAction, result.RouteValues["action"]);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestMyLog_UserHasLog_ShouldReturnRedirectToActionLogsController(string userId)
        {
            // Arrange
            var expectedController = "Logs";

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var log = new TrainingLog();
            var user = new User { Log = log };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            var result = controller.MyLog();

            // Assert
            Assert.AreEqual(expectedController, result.RouteValues["controller"]);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestMyLog_UserHasLog_ShouldReturnRedirectToActionLogsControllerDetailsWithCorrectId(string userId)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var log = new TrainingLog();
            var user = new User { Log = log };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            var result = controller.MyLog();

            // Assert
            Assert.AreEqual(log.LogId, result.RouteValues["id"]);
        }
    }
}
