using NUnit.Framework;

namespace Logs.Models.Tests.CommentTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(423)]
        public void TestCommentId_ShouldSetupCorrectly(int commentId)
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.CommentId = commentId;

            // Assert
            Assert.AreEqual(commentId, comment.CommentId);
        }

        [TestCase(1)]
        [TestCase(423)]
        public void TestEntryId_ShouldSetupCorrectly(int entryId)
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.EntryId = entryId;

            // Assert
            Assert.AreEqual(entryId, comment.EntryId);
        }

        [Test]
        public void TestEntry_ShouldSetupCorrectly()
        {
            // Arrange
            var entry = new LogEntry();

            var comment = new Comment();

            // Act
            comment.Entry = entry;

            // Assert
            Assert.AreSame(entry, comment.Entry);
        }

        [Test]
        public void TestUser_ShouldSetupCorrectly()
        {
            // Arrange
            var user = new User();

            var comment = new Comment();

            // Act
            comment.User = user;

            // Assert
            Assert.AreSame(user, comment.User);
        }


        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUserId_ShouldSetupCorrectly(string userId)
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.UserId = userId;

            // Assert
            Assert.AreEqual(userId, comment.UserId);
        }
    }
}
