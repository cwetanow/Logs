using System.Collections.Generic;
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
            user.Log = log;

            // Assert
            Assert.AreSame(log, user.Log);
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
            user.Entries = entries;

            // Assert
            CollectionAssert.AreEqual(entries, user.Entries);
        }
    }
}
