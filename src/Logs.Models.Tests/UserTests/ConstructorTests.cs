using NUnit.Framework;

namespace Logs.Models.Tests.UserTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("username", "email", "name")]
        [TestCase("other-username", "other-email", "other-name")]
        public void TestConstructor_ShouldSetUsernameCorrectly(string username, string email, string name)
        {
            // Arrange. Act
            var user = new User(username, email);

            // Assert
            Assert.AreEqual(user.UserName, username);
        }

        [TestCase("username", "email", "name")]
        [TestCase("other-username", "other-email", "other-name")]
        public void TestConstructor_ShouldSetEmailCorrectly(string username, string email, string name)
        {
            // Arrange. Act
            var user = new User(username, email);

            // Assert
            Assert.AreEqual(user.Email, email);
        }
    }
}
