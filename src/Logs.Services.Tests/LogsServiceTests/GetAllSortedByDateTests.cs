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
    public class GetAllSortedByDateTests
    {
        [Test]
        public void TestGetAllSortedByDate_ShouldCallRepositoryGetAllCorrectly()
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
            service.GetAllSortedByDate();

            // Assert
            mockedLogRepository.Verify(r =>
            r.GetAll(It.IsAny<Expression<Func<TrainingLog, bool>>>(), It.IsAny<Expression<Func<TrainingLog, DateTime>>>(), expectedDescending),
            Times.Once);
        }

        [Test]
        public void TestGetAllSortedByDate_ShouldReturnCorrectly()
        {
            // Arrange
            var logs = new List<TrainingLog>();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetAll(It.IsAny<Expression<Func<TrainingLog, bool>>>(),
                    It.IsAny<Expression<Func<TrainingLog, DateTime>>>(),
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
            var result = service.GetAllSortedByDate();

            // Assert
            CollectionAssert.AreEqual(logs, result);
        }
    }
}
