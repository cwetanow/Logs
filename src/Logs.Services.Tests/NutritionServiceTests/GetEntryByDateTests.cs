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
        [Test]
        public void TestGetEntryByDate_ShouldCallRepositoryAll()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<NutritionEntry>>();

            var service = new NutritionService(mockRepository.Object);

            // Act
            service.GetEntryByDate(new DateTime());

            // Assert
            mockRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase(29, 7, 1999)]
        public void TestGetEntryByDate_ThereIsNoEntry_ShouldReturnNull(int day, int month, int year)
        {
            // Arrange
            var date = new DateTime(year, month, day);
            var entry = new NutritionEntry();

            var entries = new List<NutritionEntry> { entry };

            var mockRepository = new Mock<IRepository<NutritionEntry>>();
            mockRepository.Setup(r => r.All).Returns(entries.AsQueryable());

            var service = new NutritionService(mockRepository.Object);

            // Act
            var result = service.GetEntryByDate(date);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(11, 11, 1111)]
        [TestCase(22, 11, 2012)]
        [TestCase(29, 7, 1999)]
        public void TestGetEntryByDate_ThereIsEntry_ShouldReturnCorrectly(int day, int month, int year)
        {
            // Arrange
            var date = new DateTime(year, month, day);
            var entry = new NutritionEntry { Date = date };

            var entries = new List<NutritionEntry> { entry };

            var mockRepository = new Mock<IRepository<NutritionEntry>>();
            mockRepository.Setup(r => r.All).Returns(entries.AsQueryable());

            var service = new NutritionService(mockRepository.Object);

            // Act
            var result = service.GetEntryByDate(date);

            // Assert
            Assert.AreSame(entry, result);
        }
    }
}
