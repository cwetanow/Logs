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
    public class EditLogDescriptionTests
    {
        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditLogDescription_ShouldCallRepositoryGetById(int logId, string newDescription)
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
            service.EditLogDescription(logId, newDescription);

            // Assert
            mockedLogRepository.Verify(r => r.GetById(logId), Times.Once);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditLogDescription_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int logId, string newDescription)
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
            service.EditLogDescription(logId, newDescription);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditLogDescription_RepositoryReturnsLog_ShouldSetLogDescription(int logId, string newDescription)
        {
            // Arrange
            var log = new TrainingLog();

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
            service.EditLogDescription(logId, newDescription);

            // Assert
            Assert.AreEqual(newDescription, log.Description);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditLogDescription_RepositoryReturnsLog_ShouldCallRepositoryUpdate(int logId, string newDescription)
        {
            // Arrange
            var log = new TrainingLog();

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
            service.EditLogDescription(logId, newDescription);

            // Assert
            mockedLogRepository.Verify(r => r.Update(log), Times.Once);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditLogDescription_RepositoryReturnsLog_ShouldCallUnitOfWorkCommit(int logId, string newDescription)
        {
            // Arrange
            var log = new TrainingLog();

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
            service.EditLogDescription(logId, newDescription);

            // Assert
            mockedUnitOfWork.Verify(r => r.Commit(), Times.Once);
        }
    }
}
