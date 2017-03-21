using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class GetLatestLogsTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public void TestGetLatestLogs_ShouldCallRepositoryAllCorrectly(int count)
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
            service.GetLatestLogs(count);

            // Assert
            mockedLogRepository.Verify(r => r.All,
                Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestGetLatestLogs_ShouldReturnCorrectly(int count)
        {
            // Arrange
            var logs = new List<TrainingLog>()
                .AsQueryable();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.All)
                .Returns(logs);

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
            var result = service.GetLatestLogs(count);

            // Assert
            CollectionAssert.AreEqual(logs, result);
        }
    }
}
