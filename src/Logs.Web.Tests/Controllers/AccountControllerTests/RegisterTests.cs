using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class RegisterTests
    {
        [Test]
        public void TestRegister_ShouldReturnView()
        {
            // Assert
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
