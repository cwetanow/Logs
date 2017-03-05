using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface IEntryService
    {
        void AddEntryToLog(string content, int logId, string userId);

        void AddCommentToLog(string content, int logId, string userId);
    }
}
