using Logs.Models;
using Logs.Web.Models.Home;
using Logs.Web.Models.Logs;
using PagedList;

namespace Logs.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        HomeViewModel CreateHomeViewModel(bool isAuthenticated);

        LogEntryViewModel CreateLogEntryViewModel(LogEntry entry, string userId);

        LogDetailsViewModel CreateLogDetailsViewModel(TrainingLog log,
            bool isAuthenticated,
            bool isOwner,
            bool canVote,
            IPagedList<LogEntryViewModel> entries);

        ShortLogViewModel CreateShortLogViewModel(TrainingLog log);

        CreateLogViewModel CreateCreateLogViewModel();
    }
}
