using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.VoteControllerTests
{
    [TestFixture]
    public class VoteTests
    {
        [TestCase(1, 12)]
        [TestCase(5, 1764)]
        [TestCase(423, 0)]
        public void TestVote_ShouldCallAuthenticationProviderCurrentUserId(int logId, int currentVoteCount)
        {
            // Arrange
            var mockedService = new Mock<IVoteService>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new VoteController(mockedService.Object, mockedProvider.Object);

            // Act
            controller.Vote(logId, currentVoteCount);

            // Assert
            mockedProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, 12, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(5, 1764, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVote_ShouldCallServiceVoteLog(int logId, int currentVoteCount, string userId)
        {
            // Arrange
            var mockedService = new Mock<IVoteService>();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new VoteController(mockedService.Object, mockedProvider.Object);

            // Act
            controller.Vote(logId, currentVoteCount);

            // Assert
            mockedService.Verify(p => p.VoteLog(logId, userId), Times.Once);
        }

        [TestCase(1, 12, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(5, 1764, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVote_ShouldReturnPartialView(int logId, int currentVoteCount, string userId)
        {
            // Arrange
            var mockedService = new Mock<IVoteService>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new VoteController(mockedService.Object, mockedProvider.Object);

            // Act
            var result = controller.Vote(logId, currentVoteCount);

            // Assert
            Assert.IsInstanceOf<PartialViewResult>(result);
        }

        [TestCase(1, 12, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 13)]
        [TestCase(5, 1764, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 1765)]
        public void TestVote_ServiceReturnsPositive_ShouldReturnCorrectly(int logId, int currentVoteCount, string userId, int expectedVotes)
        {
            // Arrange
            var mockedService = new Mock<IVoteService>();
            mockedService.Setup(s => s.VoteLog(It.IsAny<int>(), It.IsAny<string>())).Returns(expectedVotes);

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new VoteController(mockedService.Object, mockedProvider.Object);

            // Act
            var result = ((PartialViewResult)controller.Vote(logId, currentVoteCount)).Model;

            // Assert
            Assert.AreEqual(expectedVotes, result);
        }

        [TestCase(1, 12, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(5, 1764, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVote_ServiceReturnsNegative_ShouldReturnCorrectly(int logId, int currentVoteCount, string userId)
        {
            // Arrange
            var mockedService = new Mock<IVoteService>();
            mockedService.Setup(s => s.VoteLog(It.IsAny<int>(), It.IsAny<string>())).Returns(-1);

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new VoteController(mockedService.Object, mockedProvider.Object);

            // Act
            var result = ((PartialViewResult)controller.Vote(logId, currentVoteCount)).Model;

            // Assert
            Assert.AreEqual(currentVoteCount, result);
        }
    }
}
