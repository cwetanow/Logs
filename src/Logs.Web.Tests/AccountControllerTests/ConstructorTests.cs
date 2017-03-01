using System;
using Logs.Authentication.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.AccountControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(null));
        }

        [Test]
        public void TestConstructor_PassProvider_ShouldNotThrow()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.DoesNotThrow(() => new AccountController(mockedProvider.Object));
        }

        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new AccountController(mockedProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
