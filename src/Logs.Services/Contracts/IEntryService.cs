using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface IEntryService
    {
        LogEntry CreateNewEntry(string content, int logId);
    }
}
