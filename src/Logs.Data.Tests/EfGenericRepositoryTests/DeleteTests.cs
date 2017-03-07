using Logs.Data.Contracts;
using Logs.Data.Tests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class DeleteTests
    {
        [Test]
        public void TestAdd_ShouldCallDbContextSetDeleted()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeGenericRepositoryType>();

            // Act
            repository.Delete(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetDeleted(entity.Object), Times.Once);
        }
    }
}
