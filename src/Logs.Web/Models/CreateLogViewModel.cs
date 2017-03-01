using System.ComponentModel.DataAnnotations;

namespace Logs.Web.Models
{
    public class CreateLogViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}