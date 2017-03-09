namespace Logs.Services.Contracts
{
    public interface ICommentService
    {
        void EditComment(int commentId, string newContent);

        void AddCommentToLog(string content, int logId, string userId);
    }
}
