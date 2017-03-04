using System;
using Logs.Factories;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.EntryServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitialize()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act, Assert
            Assert.DoesNotThrow(() => new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object));
        }

        [Test]
        public void TestConstructor_PassLogServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                         new EntryService(null, mockedDateTimeProvider.Object, 
                         mockedFactory.Object, 
                         mockedUserService.Object,
                         mockedCommentFactory.Object));
        }

        [Test]
        public void TestConstructor_PassCommentFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                         new EntryService(mockedLogService.Object,
                         mockedDateTimeProvider.Object,
                         mockedFactory.Object,
                         mockedUserService.Object,
                         null));
        }

        [Test]
        public void TestConstructor_PassDateTimeProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                         new EntryService(mockedLogService.Object, 
                         null,
                         mockedFactory.Object,
                         mockedUserService.Object,
                         mockedCommentFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                         new EntryService(mockedLogService.Object, 
                         mockedDateTimeProvider.Object,
                         null,
                         mockedUserService.Object,
                         mockedCommentFactory.Object));
        }

        [Test]
        public void TestConstructor_PassUserServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                         new EntryService(mockedLogService.Object,
                         mockedDateTimeProvider.Object,
                         mockedFactory.Object, 
                         null,
                         mockedCommentFactory.Object));
        }
    }
}
