﻿using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
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
        public void TestEdit_ModelStateIsNotValid_ShouldNotCallCommentServiceEditCommentCorrectly(int commentId, string content)
        {
            // Arrange
            var model = new CommentViewModel { CommentId = commentId, Content = content };

            var mockedService = new Mock<ICommentService>();
            mockedService.Setup(s => s.EditComment(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Comment());

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new CommentController(mockedService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            controller.Edit(model);

            // Assert
            mockedService.Verify(s => s.EditComment(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(1, "content")]
        public void TestEdit_ShouldCallCommentServiceEditCommentCorrectly(int commentId, string content)
        {
            // Arrange
            var model = new CommentViewModel { CommentId = commentId, Content = content };

            var mockedService = new Mock<ICommentService>();
            mockedService.Setup(s => s.EditComment(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Comment());

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new CommentController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Edit(model);

            // Assert
            mockedService.Verify(s => s.EditComment(commentId, content), Times.Once);
        }

        [TestCase(1, "content")]
        public void TestEdit_ShouldSetModelContentCorrectly(int commentId, string content)
        {
            // Arrange
            var model = new CommentViewModel { CommentId = commentId, Content = content };

            var mockedService = new Mock<ICommentService>();
            mockedService.Setup(s => s.EditComment(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Comment { Content = content });

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new CommentController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = controller.Edit(model) as PartialViewResult;

            // Assert
            Assert.AreSame(content, ((CommentViewModel)result.Model).Content);
        }

        [TestCase(1, "content")]
        public void TestEdit_ShouldReturnPartialViewWithModel(int commentId, string content)
        {
            // Arrange
            var model = new CommentViewModel { CommentId = commentId, Content = content };

            var mockedService = new Mock<ICommentService>();
            mockedService.Setup(s => s.EditComment(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Comment { Content = content });

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
