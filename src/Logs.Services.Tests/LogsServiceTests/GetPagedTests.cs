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
    public class GetPagedTests
    {
        [TestCase(1, 3)]
        [TestCase(2, 14)]
        public void TestGetPaged_ShouldCallRepositoryGetPagedCorrectly(int page, int count)
        {
            // Arrange
            var expectedDescending = true;

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
            service.GetPaged(page, count);

            // Assert
            mockedLogRepository.Verify(r => r.GetPaged(null, It.IsAny<Expression<Func<TrainingLog, DateTime>>>(), page,
                count, expectedDescending), Times.Once);
        }

        [TestCase(1, 3)]
        [TestCase(2, 14)]
        public void TestGetPaged_ShouldReturnCorrectly(int page, int count)
        {
            // Arrange
            var logs = new List<TrainingLog>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetPaged(It.IsAny<Expression<Func<TrainingLog, bool>>>(),
                    It.IsAny<Expression<Func<TrainingLog, DateTime?>>>(),
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
            var result = service.GetPaged(page, count);

            // Assert
            CollectionAssert.AreEqual(logs, result);
        }
    }
}
