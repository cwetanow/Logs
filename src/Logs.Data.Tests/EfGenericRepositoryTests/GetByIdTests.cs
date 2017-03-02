using System.Data.Entity;
using Logs.Data.Contracts;
using Logs.Data.Tests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [TestCase(1)]
        [TestCase(432)]
        public void TestGetById_ShouldCallDbContextSetFind(int id)
        {
            // Arrange
            var setMock = new Mock<DbSet<FakeGenericRepositoryType>>();

            var dbContext = new Mock<ILogsDbContext>();
            dbContext.Setup(x => x.Set<FakeGenericRepositoryType>()).Returns(setMock.Object);

            var repository = new EfGenericRepository<FakeGenericRepositoryType>(dbContext.Object);

            // Act
            repository.GetById(id);

            // Assert
            setMock.Verify(x => x.Find(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(432)]
        public void TestGetById_ShouldReturnCorrectly(int id)
        {
            // Arrange
            var mockedResult = new Mock<FakeGenericRepositoryType>();

            var mockedSet = new Mock<DbSet<FakeGenericRepositoryType>>();
            mockedSet.Setup(s => s.Find(It.IsAny<object>())).Returns(mockedResult.Object);

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.Set<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new EfGenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.GetById(id);

            // Assert
            Assert.AreSame(mockedResult.Object, result);
        }
    }
}
