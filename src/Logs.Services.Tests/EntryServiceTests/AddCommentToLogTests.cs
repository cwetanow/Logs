using System;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.EntryServiceTests
{
    [TestFixture]
    public class AddCommentToLogTests
    {
        [TestCase("content", 1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("other content", 2, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestAddCommentToLog_ShouldCallDateTimeProviderGetCurrentTime(string content, int logId, string userId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Act
            service.AddCommentToLog(content, logId, userId);

            // Assert
            mockedDateTimeProvider.Verify(p => p.GetCurrenTime(), Times.Once);
        }

        [TestCase("content", 1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("other content", 2, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestAddCommentToLog_ShouldUserServiceGetUserByIdCorrectly(string content, int logId, string userId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Act
            service.AddCommentToLog(content, logId, userId);

            // Assert
            mockedUserService.Verify(s => s.GetUserById(userId), Times.Once);
        }

        [TestCase("content", 1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("other content", 2, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestAddCommentToLog_ShouldCallCommentFactoryCreateCommentCorrectly(string content, int logId, string userId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();

            var date = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrenTime())
                .Returns(date);

            var mockedFactory = new Mock<ILogEntryFactory>();

            var user = new User();

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .Returns(user);

            var mockedCommentFactory = new Mock<ICommentFactory>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Act
            service.AddCommentToLog(content, logId, userId);

            // Assert
            mockedCommentFactory.Verify(f => f.CreateComment(content, date, user), Times.Once);
        }

        [TestCase("content", 1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("other content", 2, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestAddCommentToLog_ShouldCallLogServiceAddCommentToLogCorrectly(string content, int logId, string userId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();

            var date = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrenTime())
                .Returns(date);

            var mockedFactory = new Mock<ILogEntryFactory>();

            var user = new User();

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .Returns(user);

            var comment = new Comment();

            var mockedCommentFactory = new Mock<ICommentFactory>();
            mockedCommentFactory.Setup(f => f.CreateComment(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<User>()))
                .Returns(comment);

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Act
            service.AddCommentToLog(content, logId, userId);

            // Assert
            mockedLogService.Verify(s => s.AddCommentToLog(logId, comment), Times.Once);
        }
    }
}
