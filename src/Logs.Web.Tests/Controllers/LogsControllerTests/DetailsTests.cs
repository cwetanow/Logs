﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Common;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using PagedList;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.LogsControllerTests
{
    [TestFixture]
    public class DetailsTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ShouldCallLogServiceGetTrainingLogById(int id, string userId)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            // Act
            controller.Details(id);

            // Assert
            mockedLogService.Verify(s => s.GetTrainingLogById(id), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ServiceDoesNotReturnLog_ShouldReturnHttpNotFound(int id, string userId)
        {
            // Arrange 
            var mockedLogService = new Mock<ILogService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            // Act
            var result = controller.Details(id);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ShouldCallAuthenticationProviderIsAuthenticated(int id, string userId)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            // Act
            controller.Details(id);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ShouldCallAuthenticationProviderCurrentUserId(int id, string userId)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            controller.Details(id);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ShouldCallAuthenticationProviderIsInRole(int id, string userId)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            controller.Details(id);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.IsInRole(userId, Constants.AdministratorRoleName), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", true)]
        public void TestDetails_UserIsAdmin_ShouldSetCanEditToTrue(int id, string userId, bool isAuthenticated)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);
            mockedAuthenticationProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);
            mockedAuthenticationProvider.Setup(p => p.IsInRole(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            var canEdit = false;
            mockedFactory.Setup(
                f =>
                    f.CreateLogDetailsViewModel(It.IsAny<TrainingLog>(),
                    It.IsAny<bool>(),
                        It.IsAny<bool>(),
                        It.IsAny<bool>(),
                        It.IsAny<IPagedList<LogEntryViewModel>>()))
                        .Returns((TrainingLog l,
                        bool isAuth,
                        bool edit,
                        bool canVote,
                        IPagedList<LogEntryViewModel> e) =>
                    {
                        canEdit = true;
                        return new LogDetailsViewModel();
                    });

            // Act
            controller.Details(id);

            // Assert
            Assert.IsTrue(canEdit);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", true)]
        public void TestDetails_ShouldCallFactoryCreateLogDetailsViewModel(int id, string userId, bool isAuthenticated)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);
            mockedAuthenticationProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            var expectedIsOwner = userId.Equals(user.Id);
            var expectedCanVote = (log.Votes
                .FirstOrDefault(v => v.UserId.Equals(userId))) == null && !expectedIsOwner && isAuthenticated;

            // Act
            controller.Details(id);

            // Assert
            mockedFactory.Verify(f => f.CreateLogDetailsViewModel(log,
                isAuthenticated,
                expectedIsOwner,
                expectedCanVote,
                It.IsAny<IPagedList<LogEntryViewModel>>()));
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ShouldReturnView(int id, string userId)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            var result = controller.Details(id);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ShouldCallFactoryCreateLogEntryViewModel_AsManyTimesAsLogEntriesCount(int id, string userId)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            // Act
            var result = controller.Details(id);

            // Assert
            mockedFactory.Verify(f => f.CreateLogEntryViewModel(It.IsAny<LogEntry>(), userId), Times.Exactly(log.Entries.Count));
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestDetails_ShouldSetViewWithModel(int id, string userId)
        {
            // Arrange 
            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new LogDetailsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateLogDetailsViewModel(It.IsAny<TrainingLog>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IPagedList<LogEntryViewModel>>()))
                .Returns(model);

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Details(id, 1, 1))
                .ShouldRenderDefaultView()
                .WithModel<LogDetailsViewModel>(m =>
                {
                    Assert.AreSame(model, m);
                });
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 1, 5)]
        public void TestDetails_ShouldSetCorrectEntriesToModel(int id, string userId, int page, int count)
        {
            // Arrange 
            var entry = new LogEntry { Log = new TrainingLog() };
            var entries = new List<LogEntry> { entry };

            var user = new User { Id = userId };
            var log = new TrainingLog { User = user, Entries = entries };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var entryViewModel = new LogEntryViewModel();
            var viewModelEntries = new List<LogEntryViewModel> { entryViewModel };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateLogDetailsViewModel(It.IsAny<TrainingLog>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IPagedList<LogEntryViewModel>>()))
                .Returns((TrainingLog trainingLog,
                        bool isAuthenticated,
                        bool isOwner,
                        bool canVote,
                        IPagedList<LogEntryViewModel> entriesPagedList) => new LogDetailsViewModel { Entries = viewModelEntries.ToPagedList(page, count) });

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            var result = controller.Details(id, page, count) as ViewResult;

            // Assert
            CollectionAssert.AreEqual(viewModelEntries, ((LogDetailsViewModel)result.Model).Entries);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", true)]
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", false)]
        public void TestDetails_LogContainsViewWithCurrentUser_ShouldNotBeAbleToVote(int id, string userId, bool isAuthenticated)
        {
            // Arrange 
            var vote = new Vote { UserId = userId };

            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };
            log.Votes.Add(vote);

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new LogDetailsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateLogDetailsViewModel(It.IsAny<TrainingLog>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IPagedList<LogEntryViewModel>>()))
                .Returns(model);

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            var expectedIsOwner = log.User.Id.Equals(userId);
            var expectedCanVote = (log.Votes
                .FirstOrDefault(v => v.UserId.Equals(userId))) == null && !expectedIsOwner && isAuthenticated;

            // Act
            var result = controller.Details(id) as ViewResult;

            // Assert
            Assert.AreEqual(expectedCanVote, ((LogDetailsViewModel)result.Model).CanVote);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", -10)]
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", -124)]
        public void TestDetails_PageIsNegative_ShouldSetPageToLastPage(int id, string userId, int page)
        {
            // Arrange 
            var vote = new Vote { UserId = userId };

            var user = new User { Id = userId };
            var log = new TrainingLog { User = user };
            log.Votes.Add(vote);

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTrainingLogById(It.IsAny<int>())).Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new LogDetailsViewModel();

            var currentPage = page;

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateLogDetailsViewModel(It.IsAny<TrainingLog>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<IPagedList<LogEntryViewModel>>()))
                .Returns((TrainingLog trainingLog,
                        bool isAuthenticated,
                        bool isOwner,
                        bool canVote,
                        IPagedList<LogEntryViewModel> entries) =>
                    {
                        currentPage = entries.PageNumber;
                        return model;
                    });

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            // Act
            controller.Details(id, page);

            // Assert
            Assert.AreNotEqual(page, currentPage);
        }
    }
}
