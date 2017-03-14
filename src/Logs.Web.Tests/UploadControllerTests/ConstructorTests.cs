using System;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.UploadControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            // Act
            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassUserServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UploadController(null,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object));
        }

        [Test]
        public void TestConstructor_PassAuthenticationProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UploadController(mockedUserService.Object,
                null,
                mockedCloudinaryFactory.Object));
        }

        [Test]
        public void TestConstructor_PassCloudinaryFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                null));
        }
    }
}
