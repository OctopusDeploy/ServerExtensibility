using Nevermore.Contracts;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public enum SkipMachineBehavior
    {
        None = 0,
        SkipUnavailableMachines
    }
    
    public interface IProjectConnectivityPolicy
    {
        SkipMachineBehavior SkipMachineBehavior { get; }
        ReferenceCollection TargetRoles { get; }

        bool AllowDeploymentsToNoTargets { get; }

        bool ExcludeUnhealthyTargets { get; }
    }
}