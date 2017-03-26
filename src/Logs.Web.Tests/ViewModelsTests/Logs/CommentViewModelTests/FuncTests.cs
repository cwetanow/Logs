using System;
using Logs.Models;
using Logs.Web.Models.Logs;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Logs.CommentViewModelTests
{
    [TestFixture]
    public class FuncTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", true, 1, "mucho good", "pesho")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", false, 423, "lalala", "pesho")]
        public void TestFunc_ShouldSetDateCorrectly(string userId, bool isAdmin, int commentId, string content, string username)
        {
            // Arrange
            var date = new DateTime();
            var comment = new Comment
            {
                Date = date,
                UserId = userId,
                CommentId = commentId,
                Content = content,
                User = new User { UserName = username }
            };

            // Act
            var model = CommentViewModel.FromComment(comment, userId, isAdmin);

            // Assert
            Assert.AreEqual(date, model.Date);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", true, 1, "mucho good", "pesho")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", false, 423, "lalala", "pesho")]
        public void TestFunc_UserIdsAreEqual_ShouldSetCanEditToTrue(string userId, bool isAdmin, int commentId, string content, string username)
        {
            // Arrange
            var comment = new Comment
            {
                UserId = userId,
                CommentId = commentId,
                Content = content,
                User = new User { UserName = username }
            };

            // Act
            var model = CommentViewModel.FromComment(comment, userId, isAdmin);

            // Assert
            Assert.IsTrue(model.CanEdit);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", true, 1, "mucho good", "pesho")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", false, 423, "lalala", "pesho")]
        public void TestFunc_UserIdsAreNotEqual_ShouldSetCanEditEqualToIsAdmin(string userId, bool isAdmin, int commentId, string content, string username)
        {
            // Arrange
            var comment = new Comment
            {
                UserId = userId,
                CommentId = commentId,
                Content = content,
                User = new User { UserName = username }
            };

            // Act
            var model = CommentViewModel.FromComment(comment, null, isAdmin);

            // Assert
            Assert.AreEqual(isAdmin, model.CanEdit);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", true, 1, "mucho good", "pesho")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", false, 423, "lalala", "pesho")]
        public void TestFunc_ShouldSetCommentIdCorrectly(string userId, bool isAdmin, int commentId, string content, string username)
        {
            // Arrange
            var comment = new Comment
            {
                UserId = userId,
                CommentId = commentId,
                Content = content,
                User = new User { UserName = username }
            };

            // Act
            var model = CommentViewModel.FromComment(comment, null, isAdmin);

            // Assert
            Assert.AreEqual(commentId, model.CommentId);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", true, 1, "mucho good", "pesho")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", false, 423, "lalala", "pesho")]
        public void TestFunc_ShouldSetUserCorrectly(string userId, bool isAdmin, int commentId, string content, string username)
        {
            // Arrange
            var comment = new Comment
            {
                UserId = userId,
                CommentId = commentId,
                Content = content,
                User = new User { UserName = username }
            };

            // Act
            var model = CommentViewModel.FromComment(comment, null, isAdmin);

            // Assert
            Assert.AreEqual(username, model.User);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", true, 1, "mucho good", "pesho")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", false, 423, "lalala", "pesho")]
        public void TestFunc_ShouldSetContentCorrectly(string userId, bool isAdmin, int commentId, string content, string username)
        {
            // Arrange
            var comment = new Comment
            {
                UserId = userId,
                CommentId = commentId,
                Content = content,
                User = new User { UserName = username }
            };

            // Act
            var model = CommentViewModel.FromComment(comment, null, isAdmin);

            // Assert
            Assert.AreEqual(content, model.Content);
        }
    }
}
