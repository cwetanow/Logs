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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
    }
}