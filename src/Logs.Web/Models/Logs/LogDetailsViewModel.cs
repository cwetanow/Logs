using System;
using System.Web.Mvc;
using Logs.Models;
using PagedList;

namespace Logs.Web.Models.Logs
{
    public class LogDetailsViewModel
    {
        public LogDetailsViewModel()
        {

        }

        public LogDetailsViewModel(TrainingLog log, bool isAuthenticated, bool canEdit, bool canVote, IPagedList<LogEntryViewModel> entries)
        {
            this.Description = log.Description;
            this.Name = log.Name;
            this.DateCreated = log.DateCreated;
            this.User = log.Owner;
            this.VotesCount = log.Votes.Count;
            this.LogId = log.LogId;
            this.IsAuthenticated = isAuthenticated;
            this.CanEdit = canEdit;
            this.CanVote = canVote;
            this.Entries = entries;
            this.ProfileImageUrl = log.User?.ProfileImageUrl;
        }

        public int LogId { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string ProfileImageUrl { get; set; }

        [AllowHtml]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string User { get; set; }

        public int VotesCount { get; set; }

        public IPagedList<LogEntryViewModel> Entries { get; set; }

        public bool CanEdit { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool CanVote { get; set; }
    }
}