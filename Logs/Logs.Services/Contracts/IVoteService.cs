namespace Logs.Services.Contracts
{
    public interface IVoteService
    {
        int VoteLog(int logId, string userId);
    }
}
