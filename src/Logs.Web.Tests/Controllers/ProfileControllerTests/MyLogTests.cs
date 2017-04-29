using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.ProfileControllerTests
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

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

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

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

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
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(new User());

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.MyLog())
                .ShouldRedirectTo(c => c.NoLog());
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestMyLog_UserHasLog_ShouldReturnRedirectToActionLogsControllerDetailsWithCorrectId(string userId)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var log = new TrainingLog();
            var user = new User { TrainingLog = log };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.MyLog())
                .ShouldRedirectTo((LogsController c) => c.Details(log.LogId, It.IsAny<int>(), It.IsAny<int>()));
        }
    }
}
