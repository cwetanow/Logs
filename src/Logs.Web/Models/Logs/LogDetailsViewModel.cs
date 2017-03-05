﻿using System;
using System.Linq;
using Logs.Models;
using PagedList;

namespace Logs.Web.Models.Logs
{
    public class LogDetailsViewModel
    {
        public LogDetailsViewModel(TrainingLog log)
        {
            this.Description = log.Description;
            this.Name = log.Name;
            this.DateCreated = log.DateCreated;
            this.User = log.User.Name;
            this.VotesCount = log.Votes.Count;
            this.LogId = log.LogId;

            //this.Entries = log.Entries.Select(e => new LogEntryViewModel(e))
            //    .ToPagedList(1, 2);
        }

        public int LogId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string User { get; set; }

        public int VotesCount { get; set; }

        public virtual IPagedList<LogEntryViewModel> Entries { get; set; }


        public bool IsOwner { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}