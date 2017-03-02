using System;
using System.Collections.Generic;
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
        public void TestGetLatestLogs_ShouldCallRepositoryGetPagedCorrectly(int count)
        {
            var expectedPage = 1;
            var expectedDescending = true;

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
            mockedLogRepository.Verify(r => r.GetPaged(null, It.IsAny<Expression<Func<TrainingLog, DateTime>>>(), expectedPage,
                count, expectedDescending), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestGetLatestLogs_ShouldReturnCorrectly(int count)
        {
            // Arrange
            var logs = new List<TrainingLog>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetPaged(It.IsAny<Expression<Func<TrainingLog, bool>>>(),
                    It.IsAny<Expression<Func<TrainingLog, DateTime>>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<bool>()))
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
