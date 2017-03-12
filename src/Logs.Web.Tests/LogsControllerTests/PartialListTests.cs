using System.Collections.Generic;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
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
    public class PartialListTests
    {
        [Test]
        public void TestPartialList_ShouldCallServiceGetAllSortedByDate()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                    mockedFactory.Object);

            // Act
            controller.PartialList();

            // Assert
            mockedLogService.Verify(s => s.GetAllSortedByDate(), Times.Once);
        }

        [Test]
        public void TestPartialList_CachingProviderDoesNotReturnLogs_ShouldSetCorrectViewModel()
        {
            // Arrange
            var logs = new List<TrainingLog> { new TrainingLog() };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetAllSortedByDate()).Returns(logs);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new ShortLogViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateShortLogViewModel(It.IsAny<TrainingLog>())).Returns(model);

            var mockedCachingProvider = new Mock<ICachingProvider>();
            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                           mockedFactory.Object);

            var expectedList = new List<ShortLogViewModel> { model };

            // Act
            var result = controller.PartialList() as PartialViewResult;

            // Assert
            CollectionAssert.AreEqual(expectedList, (IEnumerable<ShortLogViewModel>)result.Model);
        }
    }
}
