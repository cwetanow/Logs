using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Profile;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.ProfileControllerTests
{
    [TestFixture]
    public class NewLogTests
    {
        [Test]
        public void TestNewLog_ShouldCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var user = new User();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act
            controller.NewLog();

            // Assert
            mockedProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestNewLog_ShouldCallUserServiceGetUserById(string userId)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var user = new User();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act
            controller.NewLog();

            // Assert
            mockedService.Verify(s => s.GetUserById(userId));
        }

        [Test]
        public void TestNewLog_CurrentUserDoesNotHaveALog_ShouldReturnRedirectToRouteResult()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var user = new User();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.NewLog())
                .ShouldRedirectTo((LogsController c) => c.Create());
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestNewLog_CurrentUserHasLog_ShouldCallFactoryCreate(int logId)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var log = new TrainingLog { LogId = logId };
            var user = new User { TrainingLog = log, LogId = logId };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act
            var result = controller.NewLog();

            // Assert
            mockedFactory.Verify(f => f.CreateNewLogViewModel(logId), Times.Once);
        }

        [Test]
        public void TestNewLog_CurrentUserHasLog_ShouldSetCorrectViewModel()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var log = new TrainingLog();
            var user = new User { TrainingLog = log, LogId = log.LogId };

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var model = new NewLogViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNewLogViewModel(It.IsAny<int>())).Returns(model);

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.NewLog())
                .ShouldRenderDefaultView()
                .WithModel<NewLogViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
