using System;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.VoteControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedService = new Mock<IVoteService>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new VoteController(mockedService.Object, mockedProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new VoteController(null, mockedProvider.Object));
        }

        [Test]
        public void TestConstructor_PassProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<IVoteService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new VoteController(mockedService.Object, null));
        }
    }
}
