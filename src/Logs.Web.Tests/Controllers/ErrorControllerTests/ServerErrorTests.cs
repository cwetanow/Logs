using System.Web.Mvc;
using Logs.Web.Controllers;
using NUnit.Framework;

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

            // Act
            var result = controller.ServerError();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
