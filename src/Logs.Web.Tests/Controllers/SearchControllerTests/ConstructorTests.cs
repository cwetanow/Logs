using System;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.SearchControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new SearchController(mockedLogService.Object, mockedViewModelFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassLogServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new SearchController(null, mockedViewModelFactory.Object));
        }

        [Test]
        public void TestConstructor_PassViewModelFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new SearchController(mockedLogService.Object, null));
        }
    }
}
