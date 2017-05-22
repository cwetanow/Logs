using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class EditNutritionTests
    {
        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_ShouldCallRepositoryGetById(int id, int calories, int protein, int carbs, int fats,
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
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedNutritionRepository.Verify(f => f.GetById(id),
                Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int id, int calories, int protein, int carbs, int fats,
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
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedUnitOfWork.Verify(f => f.Commit(),
                Times.Never);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_RepositoryReturnsNull_ShouldReturnNull(int id, int calories, int protein, int carbs, int fats,
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
            var result = service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_UserIdsAreNotEqual_ShouldNotCallUnitOfWorkCommit(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedUnitOfWork.Verify(f => f.Commit(),
                Times.Never);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_DatessAreNotEqual_ShouldNotCallUnitOfWorkCommit(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedUnitOfWork.Verify(f => f.Commit(),
                Times.Never);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetCaloriesCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(calories, nutrition.Calories);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetProteinCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(protein, nutrition.Protein);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetCarbsCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(carbs, nutrition.Carbs);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetFatsCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(fats, nutrition.Fats);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetWaterCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(water, nutrition.WaterInLitres);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetFiberCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(fiber, nutrition.Fiber);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetSugarCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(sugar, nutrition.Sugar);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldSetNotesCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(notes, nutrition.Notes);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldCallRepositoryUpdate(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedNutritionRepository.Verify(r => r.Update(nutrition), Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldCallUnitOfWorkCommit(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedUnitOfWork.Verify(r => r.Commit(), Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditNutrition_NutritionMatchesDateAndUserId_ShouldReturnCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var nutrition = new Nutrition { UserId = userId, Date = date };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreSame(nutrition, result);
        }
    }
}
