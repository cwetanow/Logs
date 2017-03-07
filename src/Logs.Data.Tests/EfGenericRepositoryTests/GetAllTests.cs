using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Logs.Data.Contracts;
using Logs.Data.Tests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class GetAllTests
    {
        [Test]
        public void TestGetAll_ShouldCallDbContextSet()
        {
            // Arrange
            var data = new List<FakeGenericRepositoryType>
            {
               new FakeGenericRepositoryType(),
               new FakeGenericRepositoryType(),
               new FakeGenericRepositoryType()
            }.AsQueryable();

            var mockedSet = new Mock<IDbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            // Act
            repository.GetAll();

            // Assert
            mockedDbContext.Verify(db => db.DbSet<FakeGenericRepositoryType>(), Times.Once);
        }

        [Test]
        public void TestGetAll_WithoutExpressions_ShouldReturnCorrectly()
        {
            // Arrange
            var data = new List<FakeGenericRepositoryType>
            {
               new FakeGenericRepositoryType(),
               new FakeGenericRepositoryType(),
               new FakeGenericRepositoryType()
            }.AsQueryable();

            var mockedSet = new Mock<IDbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.GetAll();

            // Assert
            CollectionAssert.AreEqual(data, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void TestGetAll_WithSortingExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = new List<FakeGenericRepositoryType>
            {
               new FakeGenericRepositoryType {BooleanProperty = firstBoolean},
               new FakeGenericRepositoryType {BooleanProperty = secondBooleran}
            }.AsQueryable();

            var mockedSet = new Mock<IDbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeGenericRepositoryType, bool>> expression = (FakeGenericRepositoryType t) => t.BooleanProperty;

            var expected = data.Where(expression);

            // Act
            var result = repository.GetAll(expression);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void TestGetAll_WithSortingAndOrderByExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = new List<FakeGenericRepositoryType>
            {
               new FakeGenericRepositoryType {BooleanProperty = firstBoolean},
               new FakeGenericRepositoryType {BooleanProperty = secondBooleran}
            }.AsQueryable();

            var mockedSet = new Mock<IDbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeGenericRepositoryType, bool>> sortingExpression = (FakeGenericRepositoryType t) => t.BooleanProperty;
            Expression<Func<FakeGenericRepositoryType, int>> orderExpression = (t) => t.GetHashCode();

            var expected = data.Where(sortingExpression)
                .OrderBy(orderExpression);

            // Act
            var result = repository.GetAll(sortingExpression, orderExpression, false);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void TestGetAll_WithSortingAndOrderByDescendingExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = new List<FakeGenericRepositoryType>
            {
               new FakeGenericRepositoryType {BooleanProperty = firstBoolean},
               new FakeGenericRepositoryType {BooleanProperty = secondBooleran}
            }.AsQueryable();

            var mockedSet = new Mock<IDbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeGenericRepositoryType, bool>> sortingExpression = (FakeGenericRepositoryType t) => t.BooleanProperty;
            Expression<Func<FakeGenericRepositoryType, int>> orderExpression = (t) => t.GetHashCode();

            var expected = data.Where(sortingExpression)
                .OrderByDescending(orderExpression);

            // Act
            var result = repository.GetAll(sortingExpression, orderExpression, true);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void TestGetAll_WithSortingOrderByAndSelectExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = new List<FakeGenericRepositoryType>
            {
               new FakeGenericRepositoryType {BooleanProperty = firstBoolean},
               new FakeGenericRepositoryType {BooleanProperty = secondBooleran}
            }.AsQueryable();

            var mockedSet = new Mock<IDbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeGenericRepositoryType, bool>> sortingExpression = (FakeGenericRepositoryType t) => t.BooleanProperty;
            Expression<Func<FakeGenericRepositoryType, int>> orderExpression = (t) => t.GetHashCode();
            Expression<Func<FakeGenericRepositoryType, bool>> selectExpression = (t) => t.BooleanProperty;

            var expected = data.Where(sortingExpression)
                .OrderBy(orderExpression)
                .Select(selectExpression);

            // Act
            var result = repository.GetAll(sortingExpression, orderExpression, selectExpression);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
