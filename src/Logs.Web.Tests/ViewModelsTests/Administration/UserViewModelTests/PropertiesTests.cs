using System;
using Logs.Web.Areas.Administration.Models;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Administration.UserViewModelTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase("username")]
        [TestCase("batman")]
        [TestCase("superman12")]
        public void TestUsername_ShouldInitializeCorrectly(string username)
        {
            // Arrange
            var model = new UserViewModel();

            // Act
            model.Username = username;

            // Assert
            Assert.AreEqual(username, model.Username);
        }

        [TestCase("username@abv.bg")]
        [TestCase("batman@gmail.com")]
        [TestCase("superman12@sudo.apt")]
        public void TestEmail_ShouldInitializeCorrectly(string email)
        {
            // Arrange
            var model = new UserViewModel();

            // Act
            model.Email = email;

            // Assert
            Assert.AreEqual(email, model.Email);
        }

        [TestCase("9717bdf4-1ce5-4b37-947f-3c5c910048b1")]
        [TestCase("050df499-a40b-4064-9784-8ec0a2b3eba8")]
        [TestCase("eddb2a8e-90e4-402f-8551-b954eccacaf4")]
        public void TestUserId_ShouldInitializeCorrectly(string userId)
        {
            // Arrange
            var model = new UserViewModel();

            // Act
            model.UserId = userId;

            // Assert
            Assert.AreEqual(userId, model.UserId);
        }

        [TestCase("someimageurl")]
        public void TestProfileImageUrl_ShouldInitializeCorrectly(string profileImageUrl)
        {
            // Arrange
            var model = new UserViewModel();

            // Act
            model.ProfileImageUrl = profileImageUrl;

            // Assert
            Assert.AreEqual(profileImageUrl, model.ProfileImageUrl);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestIsAdministrator_ShouldInitializeCorrectly(bool isAdmin)
        {
            // Arrange
            var model = new UserViewModel();

            // Act
            model.IsAdministrator = isAdmin;

            // Assert
            Assert.AreEqual(isAdmin, model.IsAdministrator);
        }

        [Test]
        public void TestLockoutEndDate_ShouldInitializeCorrectly()
        {
            // Arrange
            var model = new UserViewModel();
            var date = new DateTime();

            // Act
            model.LockoutEndDateUtc = date;

            // Assert
            Assert.AreEqual(date, model.LockoutEndDateUtc);
        }
    }
}
