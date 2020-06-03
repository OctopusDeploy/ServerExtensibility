using Octopus.Data.Model;
using Octopus.Server.Extensibility.HostServices.Model.Channels;
using Octopus.Server.Extensibility.HostServices.Model.Environments;
using Octopus.Server.Extensibility.HostServices.Model.WorkerPools;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IDeploymentAction
    {
        string Id { get; }

        string Name { get; }
        string ActionType { get; }
        WorkerPoolIdOrName WorkerPoolIdOrName { get; }

        bool IsDisabled { get; }
        bool IsRequired { get; }

        bool CanBeUsedForProjectVersioning { get; }

        ReferenceCollection<DeploymentEnvironmentIdOrName> Environments { get; }
        ReferenceCollection<DeploymentEnvironmentIdOrName> ExcludedEnvironments { get; }

        ReferenceCollection<ChannelIdOrName> Channels { get; }

        ReferenceCollection TenantTags { get; }

        PackageReferenceCollection Packages { get; }
    }
}