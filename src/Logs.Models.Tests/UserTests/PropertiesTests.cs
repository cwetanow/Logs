using System.Collections.Generic;
using Logs.Models.Enumerations;
using NUnit.Framework;

namespace Logs.Models.Tests.UserTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void TestProperties_ShouldSetLogCorrectly()
        {
            // Arrange
            var log = new TrainingLog();
            var user = new User();

            // Act
            user.TrainingLog = log;

            // Assert
            Assert.AreSame(log, user.TrainingLog);
        }

        [Test]
        public void TestProperties_ShouldSetCommentsCorrectly()
        {
            // Arrange
            var comments = new List<Comment>();
            var user = new User();

            // Act
            user.Comments = comments;

            // Assert
            CollectionAssert.AreEqual(comments, user.Comments);
        }

        [Test]
        public void TestProperties_ShouldSetEntriesCorrectly()
        {
            // Arrange
            var entries = new List<LogEntry>();
            var user = new User();

            // Act
            user.LogEntries = entries;

            // Assert
            CollectionAssert.AreEqual(entries, user.LogEntries);
        }

        [Test]
        public void TestVotes_ShouldInitializeCorrectly()
        {
            // Arrange
            var votes = new List<Vote>();
            var user = new User();

            // Act
            user.Votes = votes;

            // Assert
            CollectionAssert.AreEqual(votes, user.Votes);
        }

        [Test]
        public void TestTrainingLogs_ShouldInitializeCorrectly()
        {
            // Arrange
            var logs = new List<TrainingLog>();
            var user = new User();

            // Act
            user.TrainingLogs = logs;

            // Assert
            CollectionAssert.AreEqual(logs, user.TrainingLogs);
        }

        [TestCase(GenderType.Female)]
        [TestCase(GenderType.Male)]
        [TestCase(GenderType.NotSelected)]
        public void TestProperties_ShouldSetGenderTypeCorrectly(GenderType genderType)
        {
            // Arrange
            var user = new User();

            // Act
            user.GenderType = genderType;

            // Assert
            Assert.AreEqual(genderType, user.GenderType);
        }
    }
}
