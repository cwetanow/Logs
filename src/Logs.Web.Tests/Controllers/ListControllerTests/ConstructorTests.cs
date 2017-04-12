using System;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.ListControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new ListController(mockedLogService.Object,
                mockedFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassLogServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new ListController(null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new ListController(mockedLogService.Object, null));
        }
    }
}
