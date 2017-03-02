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
    public class GetTopLogsTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public void TestGetTopLogs_ShouldCallRepositoryGetPagedCorrectly(int count)
        {
            var expectedPage = 1;
            var expectedDescending = false;

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
            service.GetTopLogs(count);

            // Assert
            mockedLogRepository.Verify(r => r.GetPaged(null, It.IsAny<Expression<Func<TrainingLog, int>>>(), expectedPage,
                count, expectedDescending), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestGetTopLogs_ShouldReturnCorrectly(int count)
        {
            // Arrange
            var logs = new List<TrainingLog>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetPaged(It.IsAny<Expression<Func<TrainingLog, bool>>>(),
                    It.IsAny<Expression<Func<TrainingLog, int>>>(),
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
            var result = service.GetTopLogs(count);

            // Assert
            CollectionAssert.AreEqual(logs, result);
        }
    }
}
