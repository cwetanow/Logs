using NUnit.Framework;
using System.Collections.Generic;

namespace Logs.Models.Tests.TrainingLogTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(42)]
        [TestCase(13)]
        public void TestLastEntryId_ShouldInitializeCorrectly(int lastEntryId)
        {
            // Arrange
            var log = new TrainingLog();

            // Act
            log.LastEntryId = lastEntryId;

            // Assert
            Assert.AreEqual(lastEntryId, log.LastEntryId);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUserId_ShouldInitializeCorrectly(string userId)
        {
            // Arrange
            var log = new TrainingLog();

            // Act
            log.UserId = userId;

            // Assert
            Assert.AreEqual(userId, log.UserId);
        }

     [Test]
        public void TestUsers_ShouldInitializeCorrectly()
        {
            // Arrange
            var log = new TrainingLog();
            var users = new List<User>();

            // Act
            log.Users = users;

            // Assert
            CollectionAssert.AreEqual(users, log.Users);
        }
    }
}
