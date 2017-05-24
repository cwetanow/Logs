using Logs.Models;
using System;

namespace Logs.Web.Models.Nutrition
{
    public class DateIdViewModel
    {
        public DateIdViewModel(int id, string date)
        {
            this.Id = id;
            this.FormattedDate = date;
        }

        public int Id { get; set; }

        public string FormattedDate { get; set; }
    }
}