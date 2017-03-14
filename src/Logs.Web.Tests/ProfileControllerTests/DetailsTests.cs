using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.ProfileControllerTests
{
    [TestFixture]
    public class DetailsTests
    {
        [TestCase("username")]
        [TestCase("my-username")]
        [TestCase("lalalala96")]
        public void TestDetails_ShouldCallServiceGetByUsername(string username)
        {
            // Arrange
            var user = new User();

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedService.Verify(s => s.GetUserByUsername(username), Times.Once);
        }

        [TestCase("username")]
        [TestCase("my-username")]
        [TestCase("lalalala96")]
        public void TestDetails_ShouldCallProviderCurrentUserId(string username)
        {
            // Arrange
            var user = new User();

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedProvider.Verify(s => s.CurrentUserId, Times.Once);
        }
    }
}
