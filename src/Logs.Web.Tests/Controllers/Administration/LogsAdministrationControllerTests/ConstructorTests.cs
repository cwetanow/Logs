using System;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.Administration.LogsAdministrationControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedService = new Mock<ILogService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new LogsAdministrationController(mockedService.Object, mockedFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassLogServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();       
            
            // Arrange, Act
            Assert.Throws<ArgumentNullException>(() => new LogsAdministrationController(null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<ILogService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new LogsAdministrationController(mockedService.Object, null));
        }
    }
}
