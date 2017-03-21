using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Logs.Data.Contracts;
using Logs.Data.Tests.EfGenericRepositoryTests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class AllTests
    {
        private IQueryable<FakeGenericRepositoryType> GetData()
        {
            return new List<FakeGenericRepositoryType>
            {
               new FakeGenericRepositoryType(),
               new FakeGenericRepositoryType(),
               new FakeGenericRepositoryType()
            }.AsQueryable();
        }

        [Test]
        public void TestAll_ShouldCallDbContextSet()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.All;

            // Assert
            mockedDbContext.Verify(db => db.DbSet<FakeGenericRepositoryType>(), Times.Once);
        }
    }
}
