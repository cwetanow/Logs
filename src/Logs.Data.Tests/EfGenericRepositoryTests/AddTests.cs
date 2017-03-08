using Logs.Data.Contracts;
using Logs.Data.Tests.EfGenericRepositoryTests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class AddTests
    {
        [Test]
        public void TestAdd_ShouldCallDbContextSetAdded()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeGenericRepositoryType>();

            // Act
            repository.Add(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetAdded(entity.Object), Times.Once);
        }
    }
}
