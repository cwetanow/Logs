namespace Logs.Services.Contracts
{
    public interface IEntryService
    {
        void AddEntryToLog(string content, int logId, string userId);

        void EditEntry(int entryId, string newContent);
    }
}
