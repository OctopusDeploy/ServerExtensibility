using System;
using Nevermore.Contracts;
using Octopus.Server.Extensibility.Resources;

namespace Octopus.Server.Extensibility.HostServices.Model.ServerTasks
{
    public interface IServerTask : IDocument, IHaveSpace
    {
        string Description { get; set; }
        DateTimeOffset QueueTime { get; set; }
        TimeSpan QueueTimeExpiry { get; set; }
        TimeSpan ExecutionTimeExpiry { get; set; }
        DateTimeOffset? StartTime { get; set; }
        DateTimeOffset? LastUpdatedTime { get; set; }
        DateTimeOffset? CompletedTime { get; set; }
        string ErrorMessage { get; set; }
        string ConcurrencyTag { get; set; }
        TaskState State { get; set; }
        bool HasPendingInterruptions { get; set; }
        bool HasWarningsOrErrors { get; set; }
        string ServerVersion { get; set; }
        string ServerNodeId { get; set; }
        string LogDifferentiationToken { get; set; }
        string AdditionalDescription { get; set; }
        int DurationSeconds { get; set; }
        int ChildTaskCount { get; set; }
    }
}