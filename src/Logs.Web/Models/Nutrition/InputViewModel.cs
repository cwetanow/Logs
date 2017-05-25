using System;
using System.ComponentModel.DataAnnotations;

namespace Logs.Web.Models.Nutrition
{
    public class InputViewModel
    {
        public InputViewModel()
        {

        }

        public InputViewModel(DateTime date)
        {
            this.Date = date;
        }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}