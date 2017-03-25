using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Logs.Web.Models.Logs
{
    public class CreateLogViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [AllowHtml]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MinLength(10)]
        [AllowHtml]
        public string Description { get; set; }
    }
}