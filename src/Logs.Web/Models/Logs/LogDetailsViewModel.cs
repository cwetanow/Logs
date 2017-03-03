using System;
using Logs.Models;
using PagedList;

namespace Logs.Web.Models.Logs
{
    public class LogDetailsViewModel
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual LogEntry LastEntry { get; set; }

        public string User { get; set; }

        public int VotesCount { get; set; }

        public virtual IPagedList<LogEntry> Entries { get; set; }
    }
}