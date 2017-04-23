using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.EntriesControllerTests
{
    [TestFixture]
    public class EditEntryTests
    {
        [TestCase(1, "content")]
        public void TestEditEntry_ModelStateIsNotValid_ShouldNotCallEntryServiceEditEntryCorrectly(int entryId, string content)
        {
            // Arrange
            var mockedService = new Mock<IEntryService>();
            mockedService.Setup(s => s.EditEntry(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new LogEntry());

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new EntriesController(mockedService.Object, mockedProvider.Object);
            controller.ModelState.AddModelError("", "");

            var model = new LogEntryViewModel { EntryId = entryId, Content = content };

            // Act
            controller.EditEntry(model);

            // Assert
            mockedService.Verify(s => s.EditEntry(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(1, "content")]
        public void TestEditEntry_ShouldCallEntryServiceEditEntryCorrectly(int entryId, string content)
        {
            // Arrange
            var mockedService = new Mock<IEntryService>();
            mockedService.Setup(s => s.EditEntry(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new LogEntry());

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new EntriesController(mockedService.Object, mockedProvider.Object);

            var model = new LogEntryViewModel { EntryId = entryId, Content = content };

            // Act
            controller.EditEntry(model);

            // Assert
            mockedService.Verify(s => s.EditEntry(entryId, content), Times.Once);
        }

        [TestCase(1, "content")]
        public void TestEditEntry_ShouldSetViewModelContentCorrectly(int entryId, string content)
        {
            // Arrange
            var mockedService = new Mock<IEntryService>();
            mockedService.Setup(s => s.EditEntry(It.IsAny<int>(), It.IsAny<string>()))
                  .Returns(new LogEntry { Content = content });

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new EntriesController(mockedService.Object, mockedProvider.Object);

            var model = new LogEntryViewModel { EntryId = entryId, Content = content };

            // Act
            var result = controller.EditEntry(model);

            // Assert
            Assert.AreEqual(content, ((LogEntryViewModel)result.Model).Content);
        }

        [TestCase(1, "content")]
        public void TestEditEntry_ShouldSetViewModelCorrectly(int entryId, string content)
        {
            // Arrange
            var mockedService = new Mock<IEntryService>();
            mockedService.Setup(s => s.EditEntry(It.IsAny<int>(), It.IsAny<string>()))
                 .Returns(new LogEntry { Content = content });

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new EntriesController(mockedService.Object, mockedProvider.Object);

            var model = new LogEntryViewModel { EntryId = entryId, Content = content };

            // Act, Assert
            controller
                .WithCallTo(c => c.EditEntry(model))
                .ShouldRenderPartialView("_EntryContentPartial")
                .WithModel<LogEntryViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
