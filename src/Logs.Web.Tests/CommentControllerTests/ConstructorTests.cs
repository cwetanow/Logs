using System;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.CommentControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedService = new Mock<ICommentService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new CommentController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentController(null, mockedAuthenticationProvider.Object));
        }

        [Test]
        public void TestConstructor_PassAuthenticationProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<ICommentService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentController(mockedService.Object, null));
        }
    }
}
