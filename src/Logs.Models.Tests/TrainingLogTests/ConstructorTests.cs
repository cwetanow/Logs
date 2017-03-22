using System;
using NUnit.Framework;

namespace Logs.Models.Tests.TrainingLogTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("name", "description")]
        public void TestConstructor_ShouldSetNameCorrectly(string name, string description)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User();

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreEqual(name, log.Name);
        }

        [TestCase("name", "description")]
        public void TestConstructor_ShouldSetDescription(string name, string description)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User();

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreEqual(description, log.Description);
        }

        [TestCase("name", "description")]
        public void TestConstructor_ShouldSetDateCreatedCorrectly(string name, string description)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User();

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreEqual(dateCreated, log.DateCreated);
        }

        [TestCase("name", "description")]
        public void TestConstructor_ShouldSetUserCorrectly(string name, string description)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User();

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreSame(user, log.User);
        }

        [TestCase("name", "description")]
        public void TestConstructor_ShouldSetUserLogCorrectly(string name, string description)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User();

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreSame(user.Log, log);
        }

        [TestCase("name", "description")]
        public void TestConstructor_ShouldSetLastEntryDateToDateCreated(string name, string description)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User();

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreEqual(dateCreated, log.LastEntryDate);
        }

        [TestCase("name", "description", "username")]
        public void TestConstructor_ShouldSetLastActivityUserCorrectly(string name, string description, string username)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User { UserName = username };

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreEqual(username, log.LastActivityUser);
        }

        [TestCase("name", "description", "username")]
        public void TestConstructor_ShouldSetOwnerCorrectly(string name, string description, string username)
        {
            // Arrange
            var dateCreated = new DateTime();
            var user = new User { UserName = username };

            // Act
            var log = new TrainingLog(name, description, dateCreated, user);

            // Assert
            Assert.AreEqual(username, log.Owner);
        }
    }
}
