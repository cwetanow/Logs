using Logs.Models;

namespace Logs.Factories
{
    public interface IVoteFactory
    {
        Vote CreateVote(int logId, string userId);
    }
}
