using System;
using Logs.Authentication.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.HomeControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(null));
        }

        [Test]
        public void TestConstructor_PassProviderCorrectly_ShouldInitalizeCorrectly()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new HomeController(mockedProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
