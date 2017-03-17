using System;
using Logs.Authentication.Contracts;
using Logs.Factories;
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
            // Arrange
            var mockedFactory = new Mock<IUserFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(mockedProvider.Object, null));
        }

        [Test]
        public void TestConstructor_PassProvider_ShouldNotThrow()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            // Act, Assert
            Assert.DoesNotThrow(() => new AccountController(mockedProvider.Object, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            // Act
            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
