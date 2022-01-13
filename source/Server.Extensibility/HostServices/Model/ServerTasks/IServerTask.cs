using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Octopus.Data.Model;
using Octopus.Server.MessageContracts.Features.DeploymentEnvironments;
using Octopus.Server.MessageContracts.Features.Projects;
using Octopus.Server.MessageContracts.Features.ServerTasks;
using Octopus.Server.MessageContracts.Features.Tenants;

namespace Octopus.Server.Extensibility.HostServices.Model.ServerTasks
{
    public interface IServerTask : IDocument
    {
        JObject Arguments { get; set; }
        string Description { get; set; }
        DateTimeOffset QueueTime { get; }
        TimeSpan QueueTimeExpiry { get; set; }
        TimeSpan ExecutionTimeExpiry { get; set; }
        DateTimeOffset? StartTime { get; set; }

        DateTimeOffset? CompletedTime { get; set; }

        string ErrorMessage { get; set; }
        string? ConcurrencyTag { get; set; }
        TaskState State { get; }
        bool HasPendingInterruptions { get; set; }
        bool HasWarningsOrErrors { get; set; }
        string ServerVersion { get; set; }
        string? ServerNodeId { get; set; }
        string LogDifferentiationToken { get; set; }
        string AdditionalDescription { get; set; }
        int DurationSeconds { get; set; }
        int ChildTaskCount { get; set; }
        DateTimeOffset QueueTimeExpiryDateTimeOffset { get; }

        ProjectId? ProjectId { get; set; }
        DeploymentEnvironmentId? EnvironmentId { get; set; }

        TenantId? TenantId { get; set; }

        string RunbookId { get; set; }

        string DescriptionUnique => Description + " #" + Id.Split('-').Last();

        bool CanRerun { get; }
    }
}