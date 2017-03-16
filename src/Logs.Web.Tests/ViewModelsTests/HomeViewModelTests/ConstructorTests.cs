using Logs.Web.Models.Home;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.HomeViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void TestConstructor_ShouldInitializeCorrectly(bool isAuthenticated)
        {
            // Arrange, Act
            var model = new HomeViewModel(isAuthenticated);

            // Act
            Assert.IsNotNull(model);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestConstructor_ShouldSetIsAuthenticatedCorrectly(bool isAuthenticated)
        {
            // Arrange, Act
            var model = new HomeViewModel(isAuthenticated);

            // Act
            Assert.AreEqual(isAuthenticated, model.IsAuthenticated);
        }
    }
}
