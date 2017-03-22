using Logs.Models;
using Logs.Web.Models.Profile;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Profile.UserProfileViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("mthurn@live.com")]
        [TestCase("rgarcia@optonline.net")]
        [TestCase("mxiao@yahoo.com")]
        [TestCase("fangorn@hotmail.com")]
        [TestCase("euice@outlook.com")]
        public void TestConstructor_ShouldSetEmailCorrectly(string email)
        {
            // Arrange
            var user = new User { Email = email };

            // Act
            var model = new UserProfileViewModel(user, It.IsAny<bool>());

            // Assert
            Assert.AreEqual(email, model.Email);
        }

        [TestCase("fangorn")]
        [TestCase("euice")]
        public void TestConstructor_ShouldSetUsernameCorrectly(string username)
        {
            // Arrange
            var user = new User { UserName = username };

            // Act
            var model = new UserProfileViewModel(user, It.IsAny<bool>());

            // Assert
            Assert.AreEqual(username, model.Username);
        }

        [TestCase("fangorn.com")]
        [TestCase("euice.bg")]
        public void TestConstructor_ShouldSetProfileImageUrlCorrectly(string url)
        {
            // Arrange
            var user = new User { ProfileImageUrl = url };

            // Act
            var model = new UserProfileViewModel(user, It.IsAny<bool>());

            // Assert
            Assert.AreEqual(url, model.ProfileImageUrl);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestConstructor_ShouldSetProfileImageUrlCorrectly(int logId)
        {
            // Arrange
            var user = new User { Log = new TrainingLog { LogId = logId } };

            // Act
            var model = new UserProfileViewModel(user, It.IsAny<bool>());

            // Assert
            Assert.AreEqual(logId, model.LogId);
        }
    }
}
