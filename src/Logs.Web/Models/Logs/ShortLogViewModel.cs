using System;

namespace Logs.Web.Models.Logs
{
    public class ShortLogViewModel
    {
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