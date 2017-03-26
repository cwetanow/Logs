using System;
using Logs.Web.Models.Logs;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Logs.CommentViewModelTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public void TestCanEdit_ShouldSetCorrectly(bool canEdit)
        {
            // Arrange
            var model = new CommentViewModel();

            // Act
            model.CanEdit = canEdit;

            // Assert
            Assert.AreEqual(canEdit, model.CanEdit);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(423)]
        [TestCase(1234)]
        public void TestCommentId_ShouldSetCorrectly(int commentId)
        {
            // Arrange
            var model = new CommentViewModel();

            // Act
            model.CommentId = commentId;

            // Assert
            Assert.AreEqual(commentId, model.CommentId);
        }

        [Test]
        public void TestDate_ShouldSetCorrectly()
        {
            // Arrange
            var model = new CommentViewModel();
            var date = new DateTime();

            // Act
            model.Date = date;

            // Assert
            Assert.AreEqual(date, model.Date);
        }

        [TestCase("user")]
        [TestCase("me")]
        [TestCase("owner")]
        public void TestUser_ShouldSetCorrectly(string user)
        {
            // Arrange
            var model = new CommentViewModel();

            // Act
            model.User = user;

            // Assert
            Assert.AreEqual(user, model.User);
        }

        [TestCase("ulalalalallala")]
        [TestCase("mucho comment")]
        [TestCase("nothing important")]
        public void TestContent_ShouldSetCorrectly(string content)
        {
            // Arrange
            var model = new CommentViewModel();

            // Act
            model.Content = content;

            // Assert
            Assert.AreEqual(content, model.Content);
        }
    }
}
