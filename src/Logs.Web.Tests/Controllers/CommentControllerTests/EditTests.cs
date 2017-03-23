using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.CommentControllerTests
{
    [TestFixture]
    public class EditTests
    {
        [TestCase(1, "content")]
        public void TestEdit_ShouldCallCommentServiceEditCommentCorrectly(int commentId, string content)
        {
            // Arrange
            var model = new CommentViewModel { CommentId = commentId, Content = content };

            var mockedService = new Mock<ICommentService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new CommentController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Edit(model);

            // Assert
            mockedService.Verify(s => s.EditComment(commentId, content), Times.Once);
        }

        [TestCase(1, "content")]
        public void TestEdit_ShouldReturnPartialViewWithModel(int commentId, string content)
        {
            // Arrange
            var model = new CommentViewModel { CommentId = commentId, Content = content };

            var mockedService = new Mock<ICommentService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new CommentController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Edit(model))
                .ShouldRenderPartialView("_CommentContentPartial")
                .WithModel<CommentViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
