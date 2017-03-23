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
    public class EditTests
    {
        [TestCase(1, "description", "name")]
        [TestCase(1, "new description", "name")]
        public void TestEdit_ShouldCallServiceEditLogDescriptionCorrectly(int logId, string newDescription, string newName)
        {
            // Arrange 
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                 mockedFactory.Object);

            var model = new LogDetailsViewModel
            {
                LogId = logId,
                Description = newDescription,
                Name = newName
            };

            // Act
            controller.Edit(model);

            // Assert
            mockedLogService.Verify(s => s.EditLog(logId, newDescription, newName), Times.Once);
        }

        [TestCase(1, "description", "name")]
        [TestCase(1, "new description", "name")]
        public void TestEdit_ShouldSetViewModelCorrectly(int logId, string newDescription, string newName)
        {
            // Arrange 
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            var model = new LogDetailsViewModel
            {
                LogId = logId,
                Description = newDescription,
                Name = newName
            };

            // Act, Assert
            controller
                .WithCallTo(c => c.Edit(model))
                .ShouldRenderPartialView("_LogDescription")
                .WithModel<LogDetailsViewModel>(m => Assert.AreEqual(model, m));
        }
    }
}
