using Logs.Web.Models.Logs;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Logs.CommentViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange, Act
            var model = new CommentViewModel();

            // Assert
            Assert.IsNotNull(model);
        }
    }
}
