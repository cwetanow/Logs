using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.LogsControllerTests
{
    [TestFixture]
    public class EditTests
    {
        [TestCase(1, "description")]
        [TestCase(1, "new description")]
        public void TestEdit_ShouldCallServiceEditLogDescriptionCorrectly(int logId, string newDescription)
        {
            // Arrange 
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                 mockedFactory.Object);

            var model = new LogDetailsViewModel
            {
                LogId = logId,
                Description = newDescription
            };

            // Act
            controller.Edit(model);

            // Assert
            mockedLogService.Verify(s => s.EditLogDescription(logId, newDescription), Times.Once);
        }

        [TestCase(1, "description")]
        [TestCase(1, "new description")]
        public void TestEdit_ShouldSetViewModelCorrectly(int logId, string newDescription)
        {
            // Arrange 
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            var model = new LogDetailsViewModel
            {
                LogId = logId,
                Description = newDescription
            };

            // Act
            var result = controller.Edit(model);

            // Assert
            Assert.AreEqual(newDescription, result.Model);
        }
    }
}
