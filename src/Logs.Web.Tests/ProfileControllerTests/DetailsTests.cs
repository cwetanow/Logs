using Logs.Authentication.Contracts;
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
        [TestCase("muchwow")]
        [TestCase("meBeUser")]
        [TestCase("IAMVERYGOOD")]
        public void TestDetails_ShouldCallServiceGetByUsername(string username)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedService = new Mock<IUserService>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedService.Verify(s => s.GetUserByUsername(username), Times.Once);
        }
    }
}
