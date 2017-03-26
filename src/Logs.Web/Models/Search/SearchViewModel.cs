namespace Logs.Web.Models.Search
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }

        public bool IsSearchingUsers { get; set; }

        public bool IsSearchingLogs { get; set; }
    }
}