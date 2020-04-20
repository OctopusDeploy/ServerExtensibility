using Octopus.Data.Model;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IDeploymentAction
    {
        string Id { get; }

        string Name { get; }
        string ActionType { get; }
        string WorkerPoolId { get; }

        bool IsDisabled { get; }
        bool IsRequired { get; }

        bool CanBeUsedForProjectVersioning { get; }

        ReferenceCollection Environments { get; }
        ReferenceCollection ExcludedEnvironments { get; }

        ReferenceCollection Channels { get; }

        ReferenceCollection TenantTags { get; }

        PackageReferenceCollection Packages { get; }
    }
}