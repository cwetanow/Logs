using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.ProfileControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedService = new Mock<IUserService>();

            // Act
            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new ProfileController(null, mockedService.Object));
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new ProfileController(mockedProvider.Object, null));
        }
    }
}
