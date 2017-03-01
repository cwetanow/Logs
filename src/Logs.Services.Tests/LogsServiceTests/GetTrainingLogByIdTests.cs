using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.LogsServiceTests
{
    [TestFixture]
    public class GetTrainingLogByIdTests
    {
        [TestCase(1)]
        [TestCase(453)]
        [TestCase(13)]
        public void TestGetTrainingLogById_ShouldCallRepositoryGetByIdCorrectly(int id)
        {
            // Arrange
            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();

            var service = new LogsService(mockedLogRepository.Object, mockedUnitOfWork.Object, mockedLogFactory.Object, mockedUserService.Object);

            // Act
            service.GetTrainingLogById(id);

            // Assert
            mockedLogRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(453)]
        [TestCase(13)]
        public void TestGetTrainingLogById_RepositoryReturnsLog_ShouldReturnCorrectly(int id)
        {
            // Arrange
            var mockedLog = new Mock<TrainingLog>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(mockedLog.Object);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();

            var service = new LogsService(mockedLogRepository.Object, mockedUnitOfWork.Object, mockedLogFactory.Object, mockedUserService.Object);

            // Act
            var result = service.GetTrainingLogById(id);

            // Assert
            Assert.AreSame(mockedLog.Object, result);
        }
    }
}
