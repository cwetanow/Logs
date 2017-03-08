using Logs.Data.Contracts;
using Logs.Data.Tests.EfGenericRepositoryTests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class UpdateTests
    {
        [Test]
        public void TestAdd_ShouldCallDbContextSetUpdated()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeGenericRepositoryType>();

            // Act
            repository.Update(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetUpdated(entity.Object), Times.Once);
        }
    }
}
