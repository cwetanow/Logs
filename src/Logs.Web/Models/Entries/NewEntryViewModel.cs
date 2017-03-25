using System.Web.Mvc;

namespace Logs.Web.Models.Entries
{
    public class NewEntryViewModel
    {
        [AllowHtml]
        public string Content { get; set; }

        public int LogId { get; set; }
    }
}