using Logs.Data.Contracts;
using Logs.Data.Tests.EfGenericRepositoryTests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class DeleteTests
    {
        [Test]
        public void TestDelete_ShouldCallDbContextSetDeleted()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            var repository = new EntityFrameworkRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeGenericRepositoryType>();

            // Act
            repository.Delete(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetDeleted(entity.Object), Times.Once);
        }
    }
}
