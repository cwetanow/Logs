using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.LogsControllerTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void TestCreate_ShouldCallFactoryCreateModel()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            controller.Create();

            // Assert
            mockedFactory.Verify(f => f.CreateCreateLogViewModel(), Times.Once);
        }

        [Test]
        public void TestCreate_ShouldReturnCorrectViewWithModel()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new CreateLogViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateCreateLogViewModel()).Returns(model);

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            controller
                .WithCallTo(c => c.Create())
                .ShouldRenderDefaultView()
                .WithModel<CreateLogViewModel>(m =>
                {
                    Assert.AreSame(model, m);
                });
        }
    }
}
