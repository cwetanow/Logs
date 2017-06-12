using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Web.Tests.Controllers.SubscriptionControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedService = new Mock<ISubscriptionService>();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new SubscriptionController(mockedService.Object, mockedProvider.Object, mockedFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new SubscriptionController(null, mockedProvider.Object, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<ISubscriptionService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new SubscriptionController(mockedService.Object, null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassViewModelFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedService = new Mock<ISubscriptionService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new SubscriptionController(mockedService.Object, mockedProvider.Object, null));
        }
    }
}
