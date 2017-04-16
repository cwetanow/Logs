using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Logs.Web.Models.Entries
{
    public class NewEntryViewModel
    {
        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public int LogId { get; set; }
    }
}