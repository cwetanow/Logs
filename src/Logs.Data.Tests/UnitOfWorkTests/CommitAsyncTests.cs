using Logs.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class CommitAsyncTests
    {
        [Test]
        public void TestCommitAsync_ShouldCallDbContextSaveChangesAsync()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Act
            unitOfWork.CommitAsync();

            // Assert
            mockedDbContext.Verify(c => c.SaveChangesAsync(), Times.Once);
        }
    }
}
