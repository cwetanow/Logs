using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class GetUserNutritionsSortedByDateTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestGetUserNutritionsSortedByDate_ShouldCallRepositoryAll(string userId)
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.GetUserNutritionsSortedByDate(userId);

            // Assert
            mockedNutritionRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestGetUserNutritionsSortedByDate_ShouldFilterAndReturnCorrectly(string userId)
        {
            // Arrange
            var nutritions = new List<Nutrition>
            {
                new Nutrition {UserId=userId },
                new Nutrition {UserId=userId },
                new Nutrition ()
            }.AsQueryable();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.All).Returns(nutritions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            var expected = nutritions.Where(m => m.UserId == userId);

            // Act
            var result = service.GetUserNutritionsSortedByDate(userId);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
