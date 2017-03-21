using System;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Administration.LogsAdministrationControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedService = new Mock<ILogService>();

            // Act
            var controller = new LogsAdministrationController(mockedService.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassLogServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new LogsAdministrationController(null));
        }
    }
}
