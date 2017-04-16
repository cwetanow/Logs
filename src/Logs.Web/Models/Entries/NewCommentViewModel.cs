using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Logs.Web.Models.Entries
{
    public class NewCommentViewModel
    {
        [AllowHtml]
        [Required]
        public string Content { get; set; }

        public int LogId { get; set; }
    }
}