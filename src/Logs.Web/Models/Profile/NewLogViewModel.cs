namespace Logs.Web.Models.Profile
{
    public class NewLogViewModel
    {
        public NewLogViewModel()
        {
            
        }

        public NewLogViewModel(int logId)
        {
            this.LogId = logId;
        }

        public int LogId { get; set; }
    }
}