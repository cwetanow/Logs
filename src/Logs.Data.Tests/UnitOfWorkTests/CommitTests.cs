using Logs.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class CommitTests
    {
        [Test]
        public void TestCommit_ShouldCallDbContextSaveChanges()
        {
            // Arrange
            var mockedDbContext = new Mock<ILogsDbContext>();

            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Act
            unitOfWork.Commit();

            // Assert
            mockedDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
