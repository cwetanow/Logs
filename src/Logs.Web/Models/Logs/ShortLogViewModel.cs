using System;
using System.Web.Mvc;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class ShortLogViewModel
    {
        public ShortLogViewModel()
        {

        }

        public ShortLogViewModel(TrainingLog log)
        {
            this.DateCreated = log.DateCreated;
            this.Entries = log.LogEntries.Count;
            this.LastActivity = log.LastEntryDate;
            this.Name = log.Name;
            this.LastActivityUser = log.LastActivityUser;
            this.LogId = log.LogId;
            this.Votes = log.Votes.Count;
            this.Username = log.Owner;
        }

        [AllowHtml]
        public string Name { get; set; }

        public int LogId { get; set; }

        public string Username { get; set; }

        public DateTime DateCreated { get; set; }

        public int Entries { get; set; }

        public int Votes { get; set; }

        public string LastActivityUser { get; set; }

        public DateTime? LastActivity { get; set; }
    }
}