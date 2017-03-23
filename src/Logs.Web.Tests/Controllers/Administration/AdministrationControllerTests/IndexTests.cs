using System.Web.Mvc;
using Logs.Web.Areas.Administration.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.Administration.AdministrationControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void TestIndex_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new AdministrationController();

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
