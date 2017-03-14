using System.Web.Mvc;
using Logs.Web.Controllers;
using NUnit.Framework;

namespace Logs.Web.Tests.ErrorControllerTests
{
    [TestFixture]
    public class NotFoundTests
    {
        [Test]
        public void TestNotFound_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new ErrorController();

            // Act
            var result = controller.NotFound();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
