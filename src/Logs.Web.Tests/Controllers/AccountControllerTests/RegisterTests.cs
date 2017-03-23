using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Web.Controllers;
using Logs.Web.Models.Account;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

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

            // Act, Assert
            controller
                .WithCallTo(c => c.Register())
                .ShouldRenderDefaultView();
        }
    }
}
