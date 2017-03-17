using System;
using NUnit.Framework;

namespace Logs.Models.Tests.CommentTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange, Act
            var comment = new Comment();

            // Assert
            Assert.IsNotNull(comment);
        }

        [TestCase("content")]
        public void TestConstructor_ShouldSetContentCorrectly(string content)
        {
            // Arrange
            var user = new User();
            var date = new DateTime();

            // Act
            var comment = new Comment(content, date, user);

            // Assert
            Assert.AreEqual(content, comment.Content);
        }

        [TestCase("content")]
        public void TestConstructor_ShouldSetDateCorrectly(string content)
        {
            // Arrange
            var user = new User();
            var date = new DateTime();

            // Act
            var comment = new Comment(content, date, user);

            // Assert
            Assert.AreEqual(date, comment.Date);
        }

        [TestCase("content")]
        public void TestConstructor_ShouldSetUserCorrectly(string content)
        {
            // Arrange
            var user = new User();
            var date = new DateTime();

            // Act
            var comment = new Comment(content, date, user);

            // Assert
            Assert.AreSame(user, comment.User);
        }

        [TestCase("content")]
        public void TestConstructor_PassValidParameters_ShouldInitalizeCorrectly(string content)
        {
            // Arrange
            var user = new User();
            var date = new DateTime();

            // Act
            var comment = new Comment(content, date, user);

            // Assert
            Assert.IsNotNull(comment);
        }
    }
}
