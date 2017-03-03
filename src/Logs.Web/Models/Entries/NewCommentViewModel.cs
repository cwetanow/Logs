namespace Logs.Web.Models.Entries
{
    public class NewCommentViewModel
    {
        public string Content { get; set; }

        public int LogId { get; set; }

        public string UserId { get; set; }
    }
}