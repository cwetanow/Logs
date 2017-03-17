using System;
using Logs.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [Test]
        public void TestConstructor_PassDbContextCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            // Act, Assert
            Assert.DoesNotThrow(() => new UnitOfWork(mockedDbContext.Object));
        }

        [Test]
        public void TestConstructor_PassDbContextCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            // Act
            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(unitOfWork);
        }
    }
}
