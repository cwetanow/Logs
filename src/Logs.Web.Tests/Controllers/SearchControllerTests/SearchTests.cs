using System.Collections;
using System.Collections.Generic;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Logs.Web.Models.Search;
using Moq;
using NUnit.Framework;
using PagedList;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.SearchControllerTests
{
    [TestFixture]
    public class SearchTests
    {
        [TestCase("search")]
        [TestCase("bb")]
        [TestCase("text")]
        public void TestSearch_ShouldCallLogsServiceSearchCorrectly(string searchTerm)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SearchController(mockedLogService.Object, mockedViewModelFactory.Object);

            var model = new SearchViewModel { SearchTerm = searchTerm };

            // Act
            controller.Search(model);

            // Assert
            mockedLogService.Verify(s => s.Search(searchTerm), Times.Once);
        }

        [TestCase("search")]
        [TestCase("bb")]
        [TestCase("text")]
        public void TestSearch_ShouldReturnCorrectPartialViewWithModel(string searchTerm)
        {
            // Arrange
            var logs = new List<TrainingLog> { new TrainingLog(), new TrainingLog() };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.Search(It.IsAny<string>())).Returns(logs);

            var viewModel = new ShortLogViewModel();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateShortLogViewModel(It.IsAny<TrainingLog>())).Returns(viewModel);

            var controller = new SearchController(mockedLogService.Object, mockedViewModelFactory.Object);

            var model = new SearchViewModel { SearchTerm = searchTerm };

            var expectedModelList = new List<ShortLogViewModel> { viewModel, viewModel };

            // Act, Assert
            controller
                .WithCallTo(c => c.Search(model))
                .ShouldRenderPartialView("_LogListPartial")
                .WithModel<IEnumerable<ShortLogViewModel>>(m =>
                {
                    CollectionAssert.AreEqual(expectedModelList, m);
                });
        }
    }
}
