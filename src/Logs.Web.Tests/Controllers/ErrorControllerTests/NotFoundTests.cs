using System.Web.Mvc;
using Logs.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.ErrorControllerTests
{
    [TestFixture]
    public class NotFoundTests
    {
        [Test]
        public void TestNotFound_ShouldReturnView()
        {
            // Arrange
            var controller = new ErrorController();

            // Act, Assert
            controller
                .WithCallTo(c => c.NotFound())
                .ShouldRenderDefaultView();
        }
    }
}
