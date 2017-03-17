using System;
using Logs.Authentication.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.NavigationControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassAuthProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            Assert.Throws<ArgumentNullException>(() =>
                new NavigationController(null, mockedViewModelFactory.Object));
        }

        [Test]
        public void TestConstructor_PassViewModelFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();

            // Act
            Assert.Throws<ArgumentNullException>(() =>
                new NavigationController(mockedAuthProvider.Object, null));
        }
    }
}
