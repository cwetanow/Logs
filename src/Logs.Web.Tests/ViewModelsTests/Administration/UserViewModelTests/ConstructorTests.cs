using Logs.Web.Areas.Administration.Models;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Administration.UserViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange, Act
            var model = new UserViewModel();

            // Assert
            Assert.IsNotNull(model);
        }
    }
}
