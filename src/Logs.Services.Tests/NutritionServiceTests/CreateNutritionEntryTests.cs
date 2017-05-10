using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class CreateNutritionEntryTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 2211, 12, 27)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 1888, 6, 12)]
        public void TestCreateNutritionEntry_ShouldCallNutritionFactoryCreateNutritionEntry(string userId, int year, int month, int day)
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var date = new DateTime(year, month, day);

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.CreateNutritionEntry(userId, date);

            // Assert
            mockedNutritionFactory.Verify(f => f.CreateNutritionEntry(userId, date), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 2211, 12, 27)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 1888, 6, 12)]
        public void TestCreateNutritionEntry_ShouldCallEntryRepositoryAdd(string userId, int year, int month, int day)
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var entry = new NutritionEntry();

            var mockedNutritionFactory = new Mock<INutritionFactory>();
            mockedNutritionFactory.Setup(f => f.CreateNutritionEntry(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(entry);

            var date = new DateTime(year, month, day);

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.CreateNutritionEntry(userId, date);

            // Assert
            mockedEntryRepository.Verify(r => r.Add(entry), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 2211, 12, 27)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 1888, 6, 12)]
        public void TestCreateNutritionEntry_ShouldCallUnitOfWorkCommit(string userId, int year, int month, int day)
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var date = new DateTime(year, month, day);

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.CreateNutritionEntry(userId, date);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 2211, 12, 27)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 1888, 6, 12)]
        public void TestCreateNutritionEntry_ShouldReturnCorrectly(string userId, int year, int month, int day)
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var entry = new NutritionEntry();

            var mockedNutritionFactory = new Mock<INutritionFactory>();
            mockedNutritionFactory.Setup(f => f.CreateNutritionEntry(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(entry);

            var date = new DateTime(year, month, day);

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.CreateNutritionEntry(userId, date);

            // Assert
            Assert.AreSame(entry, result);
        }
    }
}
