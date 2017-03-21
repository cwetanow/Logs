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
    public class DeleteLogTests
    {
        [TestCase(1)]
        [TestCase(4578)]
        [TestCase(123)]
        public void TestDeleteLog_ShouldCallRepositoryGetById(int logId)
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
            service.DeleteLog(logId);

            // Assert
            mockedLogRepository.Verify(r => r.GetById(logId), Times.Once);
        }

        [TestCase(1)]
        [TestCase(4578)]
        [TestCase(123)]
        public void TestDeleteLog_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int logId)
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
            service.DeleteLog(logId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1)]
        [TestCase(4578)]
        [TestCase(123)]
        public void TestDeleteLog_RepositoryReturnsLog_ShouldSetUserLogToNull(int logId)
        {
            // Arrange
            var user = new User();

            var log = new TrainingLog { User = user };
            user.Log = log;

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(log);

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
            service.DeleteLog(logId);

            // Assert
            Assert.IsNull(user.Log);
        }

        [TestCase(1)]
        [TestCase(4578)]
        [TestCase(123)]
        public void TestDeleteLog_RepositoryReturnsLog_ShouldCallRepositoryDelete(int logId)
        {
            // Arrange
            var user = new User();

            var log = new TrainingLog { User = user };
            user.Log = log;

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(log);

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
            service.DeleteLog(logId);

            // Assert
            mockedLogRepository.Verify(r => r.Delete(log), Times.Once);
        }

        [TestCase(1)]
        [TestCase(4578)]
        [TestCase(123)]
        public void TestDeleteLog_RepositoryReturnsLog_ShouldCallUnitOfWorkCommit(int logId)
        {
            // Arrange
            var user = new User();

            var log = new TrainingLog { User = user };
            user.Log = log;

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(log);

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
            service.DeleteLog(logId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }
    }
}
