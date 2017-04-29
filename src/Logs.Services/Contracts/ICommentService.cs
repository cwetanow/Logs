using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface ICommentService
    {
        Comment EditComment(int commentId, string newContent);

        void AddCommentToLog(string content, int logId, string userId);

        bool DeleteComment(int commentId);
    }
}
