using System.Web.Mvc;
using Logs.Web.Areas.Administration.Controllers;
using NUnit.Framework;

namespace Logs.Web.Tests.Administration.AdministrationControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void TestIndex_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new AdministrationController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
