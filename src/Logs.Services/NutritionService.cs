﻿using System;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Models;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class NutritionService : INutritionService
    {
        private readonly IRepository<NutritionEntry> entryRepository;

        public NutritionService(IRepository<NutritionEntry> entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public NutritionEntry GetEntryByDate(DateTime date)
        {
            var entry = this.entryRepository.All
                .FirstOrDefault(e => e.Date.Date == date.Date && e.Date.Year == date.Year && e.Date.Day == date.Day);

            return entry;
        }
    }
}
