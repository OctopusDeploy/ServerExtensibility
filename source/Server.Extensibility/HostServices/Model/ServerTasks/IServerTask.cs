using System;
using Nevermore.Contracts;
using Octopus.Server.Extensibility.Resources;

namespace Octopus.Server.Extensibility.HostServices.Model.ServerTasks
{
    public interface IServerTask : IDocument, IHaveSpace
    {
        string ProjectId { get; }
        string EnvironmentId { get; }
        string TenantId { get; }

        string Description { get; }
        DateTimeOffset QueueTime { get; }
        TimeSpan QueueTimeExpiry { get; }
        TimeSpan ExecutionTimeExpiry { get; }
        DateTimeOffset? StartTime { get; }
        DateTimeOffset? LastUpdatedTime { get; }
        DateTimeOffset? CompletedTime { get; }
        string ErrorMessage { get; }
        string ConcurrencyTag { get; }
        TaskState State { get; }
        bool HasPendingInterruptions { get; }
        bool HasWarningsOrErrors { get; }
        string ServerVersion { get; }
        string ServerNodeId { get; }
        string LogDifferentiationToken { get; }
        string AdditionalDescription { get; }
        int DurationSeconds { get; }
        int ChildTaskCount { get; }

        DateTimeOffset QueueTimeExpiryDateTimeOffset { get; }

        string GetCorrelationId();
    }
}