using System;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.LogsServiceTests
{
    [TestFixture]
    public class CreateTrainingLogTests
    {
        [TestCase("log", "test", "abcd-1234")]
        public void TestCreateTrainingLog_ShouldCallUserServiceGetById(string name, string description, string userId)
        {
            // Arrange
            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.CreateTrainingLog(name, description, userId);

            // Assert
            mockedUserService.Verify(s => s.GetUserById(userId), Times.Once);
        }

        [TestCase("log", "test", "abcd-1234")]
        public void TestCreateTrainingLog_ShouldCallProviderGetCurrentTime(string name, string description, string userId)
        {
            // Arrange
            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.CreateTrainingLog(name, description, userId);

            // Assert
            mockedDateTimeProvider.Verify(p => p.GetCurrentTime(), Times.Once);
        }

        [TestCase("log", "test", "abcd-1234")]
        public void TestCreateTrainingLog_ShouldCallLogFactoryCreateTrainingLog(string name, string description, string userId)
        {
            // Arrange
            var mockedUser = new Mock<User>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();

            var currentDate = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime()).Returns(currentDate);

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.CreateTrainingLog(name, description, userId);

            // Assert
            mockedLogFactory.Verify(f => f.CreateTrainingLog(name, description, currentDate, mockedUser.Object));
        }

        [TestCase("log", "test", "abcd-1234")]
        public void TestCreateTrainingLog_ShouldCallRepositoryAddCorrectly(string name, string description, string userId)
        {
            // Arrange
            var mockedUser = new Mock<User>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var mockedLog = new Mock<TrainingLog>();

            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            mockedLogFactory.Setup(
                f => f.CreateTrainingLog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                    It.IsAny<User>())).Returns(mockedLog.Object);

            var currentDate = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime()).Returns(currentDate);

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.CreateTrainingLog(name, description, userId);

            // Assert
            mockedLogRepository.Verify(r => r.Add(mockedLog.Object), Times.Once);
        }

        [TestCase("log", "test", "abcd-1234")]
        public void TestCreateTrainingLog_ShouldCallUnitOfWorkCommit(string name, string description, string userId)
        {
            // Arrange
            var mockedUser = new Mock<User>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var mockedLog = new Mock<TrainingLog>();

            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            mockedLogFactory.Setup(
                f => f.CreateTrainingLog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                    It.IsAny<User>())).Returns(mockedLog.Object);

            var currentDate = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime()).Returns(currentDate);

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.CreateTrainingLog(name, description, userId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }



        [TestCase("log", "test", "abcd-1234")]
        public void TestCreateTrainingLog_ShouldReturnCorrectly(string name, string description, string userId)
        {
            // Arrange
            var mockedUser = new Mock<User>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var mockedLog = new Mock<TrainingLog>();

            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            mockedLogFactory.Setup(
                f => f.CreateTrainingLog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                    It.IsAny<User>())).Returns(mockedLog.Object);

            var currentDate = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime()).Returns(currentDate);

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            var result = service.CreateTrainingLog(name, description, userId);

            // Assert
            Assert.AreSame(mockedLog.Object, result);
        }
    }
}
