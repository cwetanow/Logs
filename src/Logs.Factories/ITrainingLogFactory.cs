using System;
using Logs.Models;

namespace Logs.Factories
{
    public interface ITrainingLogFactory
    {
        TrainingLog CreateTrainingLog(string name, string description, DateTime dateCreated, User user);
    }
}
