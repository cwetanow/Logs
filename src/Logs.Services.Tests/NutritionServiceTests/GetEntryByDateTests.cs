using System;
using System.Collections.Generic;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class GetEntryByDateTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestGetEntryByDate_ShouldCallRepositoryAll(string userId)
        {
            // Arrange
            var mockRepository = new Mock<IRepository<NutritionEntry>>();

            var service = new NutritionService(mockRepository.Object);

            // Act
            service.GetEntryByDate(userId, new DateTime());

            // Assert
            mockRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 29, 7, 1999)]
        public void TestGetEntryByDate_ThereIsNoEntry_ShouldReturnNull(string userId, int day, int month, int year)
        {
            // Arrange
            var date = new DateTime(year, month, day);
            var entry = new NutritionEntry();

            var entries = new List<NutritionEntry> { entry };

            var mockRepository = new Mock<IRepository<NutritionEntry>>();
            mockRepository.Setup(r => r.All).Returns(entries.AsQueryable());

            var service = new NutritionService(mockRepository.Object);

            // Act
            var result = service.GetEntryByDate(userId, date);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 11, 11, 1111)]
        public void TestGetEntryByDate_ThereIsEntry_ShouldReturnCorrectly(string userId, int day, int month, int year)
        {
            // Arrange
            var date = new DateTime(year, month, day);
            var entry = new NutritionEntry { Date = date, UserId = userId };

            var entries = new List<NutritionEntry> { entry };

            var mockRepository = new Mock<IRepository<NutritionEntry>>();
            mockRepository.Setup(r => r.All).Returns(entries.AsQueryable());

            var service = new NutritionService(mockRepository.Object);

            // Act
            var result = service.GetEntryByDate(userId, date);

            // Assert
            Assert.AreSame(entry, result);
        }
    }
}
