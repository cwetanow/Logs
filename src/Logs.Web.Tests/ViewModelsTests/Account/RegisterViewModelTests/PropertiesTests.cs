using Logs.Web.Models.Account;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Account.RegisterViewModelTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase("fancy-stron-password-1234")]
        [TestCase("password")]
        public void TestConfirmPassword_ShouldSetCorrectly(string confirm)
        {
            // Arrange
            var model = new RegisterViewModel();

            // Act
            model.ConfirmPassword = confirm;

            // Assert
            Assert.AreEqual(confirm, model.ConfirmPassword);
        }
    }
}
