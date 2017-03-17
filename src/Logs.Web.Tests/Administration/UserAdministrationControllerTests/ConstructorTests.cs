using System;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Administration.UserAdministrationControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassUserServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new UserAdministrationController(null, mockedAuthProvider.Object));
        }

        [Test]
        public void TestConstructor_PassAuthProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new UserAdministrationController(mockedUserService.Object, null));
        }
    }
}
