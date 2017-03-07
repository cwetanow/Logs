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
            var mockedSet = new Mock<DbSet<FakeGenericRepositoryType>>();

            var mockedDbContext = new Mock<ILogsDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            // Act
            repository.GetById(id);

            // Assert
            mockedSet.Verify(x => x.Find(id), Times.Once);
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
            mockedDbContext.Setup(x => x.DbSet<FakeGenericRepositoryType>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.GetById(id);

            // Assert
            Assert.AreSame(mockedResult.Object, result);
        }
    }
}
