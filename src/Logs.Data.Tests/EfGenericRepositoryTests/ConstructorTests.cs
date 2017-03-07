using System;
using Logs.Data.Contracts;
using Logs.Data.Tests.Fakes;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.EfGenericRepositoryTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new GenericRepository<FakeGenericRepositoryType>(null));
        }

        [Test]
        public void TestConstructor_PassDbContextCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            // Act, Assert
            Assert.DoesNotThrow(() => new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object));
        }

        [Test]
        public void TestConstructor_PassDbContextCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            // Act
            var repository = new GenericRepository<FakeGenericRepositoryType>(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(repository);
        }
    }
}
