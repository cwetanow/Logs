using Logs.Web.Models.Navigation;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Navigation.NavigationViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("username", true, false)]
        [TestCase("lalalala", false, false)]
        [TestCase("myusername", true, true)]
        public void TestConstructor_ShouldInitializeCorrectly(string username, bool isAuthenticated, bool isAdmin)
        {
            // Arrange, Act
            var model = new NavigationViewModel(username, isAuthenticated, isAdmin);

            // Assert 
            Assert.IsNotNull(model);
        }

        [TestCase("username", true, false)]
        [TestCase("lalalala", false, false)]
        [TestCase("myusername", true, true)]
        public void TestConstructor_ShouldSetUsernameCorrectly(string username, bool isAuthenticated, bool isAdmin)
        {
            // Arrange, Act
            var model = new NavigationViewModel(username, isAuthenticated, isAdmin);

            // Assert 
            Assert.AreEqual(username, model.Username);
        }

        [TestCase("username", true, false)]
        [TestCase("lalalala", false, false)]
        [TestCase("myusername", true, true)]
        public void TestConstructor_ShouldSetIsAuthenticatedCorrectly(string username, bool isAuthenticated, bool isAdmin)
        {
            // Arrange, Act
            var model = new NavigationViewModel(username, isAuthenticated, isAdmin);

            // Assert 
            Assert.AreEqual(isAuthenticated, model.IsAuthenticated);
        }

        [TestCase("username", true, false)]
        [TestCase("lalalala", false, false)]
        [TestCase("myusername", true, true)]
        public void TestConstructor_ShouldSetIsAdminCorrectly(string username, bool isAuthenticated, bool isAdmin)
        {
            // Arrange, Act
            var model = new NavigationViewModel(username, isAuthenticated, isAdmin);

            // Assert 
            Assert.AreEqual(isAdmin, model.IsAdmin);
        }
    }
}
