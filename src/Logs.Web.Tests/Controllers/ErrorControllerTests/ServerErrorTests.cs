using System.Web.Mvc;
using Logs.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.ErrorControllerTests
{
    [TestFixture]
    public class ServerErrorTests
    {
        [Test]
        public void TestServerError_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new ErrorController();

            // Act, Assert
            controller
                .WithCallTo(c => c.ServerError())
                .ShouldRenderDefaultView();
        }
    }
}
