using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class CreateNutritionTests
    {
        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateNutrition_ShouldCallRepositoryAll(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange
            var date = new DateTime(2, 3, 4);

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            mockedNutritionRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateNutrition_RepositoryReturnsNutrition_ShouldReturnNutrition(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange
            var date = new DateTime(2, 3, 4);
            var nutrition = new Nutrition { Date = date, UserId = userId };

            var results = new List<Nutrition> { nutrition };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.All).Returns(results.AsQueryable());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreSame(nutrition, result);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateNutrition_RepositoryReturnsNutrition_ShouldNotCallFactoryCreateNutrition(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange
            var date = new DateTime(2, 3, 4);
            var nutrition = new Nutrition { Date = date, UserId = userId };

            var results = new List<Nutrition> { nutrition };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.All).Returns(results.AsQueryable());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            mockedFactory.Verify(f => f.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date),
                 Times.Never);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateNutrition_ShouldCallFactoryCreateNutritionCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            mockedFactory.Verify(f => f.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date),
                Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateNutrition_ShouldCallRepositoryAdd(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var nutrition = new Nutrition();

            var mockedFactory = new Mock<INutritionFactory>();
            mockedFactory.Setup(f => f.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(nutrition);

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            mockedNutritionRepository.Verify(n => n.Add(nutrition), Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateNutrition_ShouldCallUnitOfWorkCommit(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var nutrition = new Nutrition();

            var mockedFactory = new Mock<INutritionFactory>();
            mockedFactory.Setup(f => f.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(nutrition);

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateNutrition_ShouldReturnCorrectly(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var nutrition = new Nutrition();

            var mockedFactory = new Mock<INutritionFactory>();
            mockedFactory.Setup(f => f.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(nutrition);

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreSame(nutrition, result);
        }
    }
}
