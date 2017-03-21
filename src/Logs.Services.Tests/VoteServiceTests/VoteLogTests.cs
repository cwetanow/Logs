using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.VoteServiceTests
{
    [TestFixture]
    public class VoteLogTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_RepositoryReturnsVote_ShouldReturnMinusOne(int logId, string userId)
        {
            // Arrange
            var vote = new Vote();
            var votes = new List<Vote> { vote }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Vote>>();
            mockedRepository.Setup(r => r.All).Returns(votes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object,
                mockedVoteFactory.Object);

            var expected = -1;

            // Act
            var result = service.VoteLog(logId, userId);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_RepositoryReturnsVote_ShouldNotCallLogServiceGetById(int logId, string userId)
        {
            // Arrange
            var vote = new Vote { LogId = logId, UserId = userId };
            var votes = new List<Vote> { vote }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Vote>>();
            mockedRepository.Setup(r => r.All).Returns(votes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object,
                mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedLogService.Verify(s => s.GetTrainingLogById(It.IsAny<int>()), Times.Never());
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_ShouldCallRepositoryAll(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_RepositoryReturnsNothing_ShouldCallLogServiceGetTrainingLogByIdCorrectly(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedLogService.Verify(s => s.GetTrainingLogById(logId), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsNull_ShouldReturnMinusOne(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            var expected = -1;

            // Act
            var result = service.VoteLog(logId, userId);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsNull_ShouldNotCallVoteFactoryCreateVote(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedVoteFactory.Verify(f => f.CreateVote(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsNull_ShouldNotCallUnitOfWorkCommit(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsNull_ShouldNotCallVoteRepositoryAdd(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedRepository.Verify(r => r.Add(It.IsAny<Vote>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsLog_ShouldCallFactoryCreateVoteCorrectly(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var log = new TrainingLog();

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedVoteFactory = new Mock<IVoteFactory>();

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedVoteFactory.Verify(f => f.CreateVote(logId, userId), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsLog_ShouldCallRepositoryAddCorrectly(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var log = new TrainingLog();

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var vote = new Vote();

            var mockedVoteFactory = new Mock<IVoteFactory>();
            mockedVoteFactory.Setup(f => f.CreateVote(It.IsAny<int>(), It.IsAny<string>())).Returns(vote);

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedRepository.Verify(r => r.Add(vote), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsLog_ShouldCallUnitOfWorkCommitCorrectly(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var log = new TrainingLog();

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var vote = new Vote();

            var mockedVoteFactory = new Mock<IVoteFactory>();
            mockedVoteFactory.Setup(f => f.CreateVote(It.IsAny<int>(), It.IsAny<string>())).Returns(vote);

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            // Act
            service.VoteLog(logId, userId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestVoteLog_LogServiceReturnsLog_ShouldReturnCorrectly(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var log = new TrainingLog();

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var vote = new Vote();

            log.Votes.Add(vote);

            var mockedVoteFactory = new Mock<IVoteFactory>();
            mockedVoteFactory.Setup(f => f.CreateVote(It.IsAny<int>(), It.IsAny<string>())).Returns(vote);

            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object, mockedVoteFactory.Object);

            var expected = log.Votes.Count;

            // Act
            var result = service.VoteLog(logId, userId);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
