using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.SearchControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void TestIndex_ShouldReturnCorrectView()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SearchController(mockedLogService.Object, mockedViewModelFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
