using System;
using System.ComponentModel.DataAnnotations;

namespace Logs.Web.Models.Nutrition
{
    public class InputViewModel
    {
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        public DateTime Date { get; set; }
    }
}