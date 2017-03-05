namespace Logs.Services.Contracts
{
    public interface IVoteService
    {
        bool VoteLog(int logId, string userId);
    }
}
