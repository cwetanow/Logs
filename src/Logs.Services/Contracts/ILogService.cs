using System;
using System.Collections.Generic;
using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface ILogService
    {
        TrainingLog GetTrainingLogById(int id);

        TrainingLog CreateTrainingLog(string name, string description, string userId);

        IEnumerable<TrainingLog> GetLogs();
    }
}
