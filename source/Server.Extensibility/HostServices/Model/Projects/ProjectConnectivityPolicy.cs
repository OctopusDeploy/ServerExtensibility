using Nevermore.Contracts;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public enum SkipMachineBehavior
    {
        None = 0,
        SkipUnavailableMachines
    }
    
    public class ProjectConnectivityPolicy
    {
        public SkipMachineBehavior SkipMachineBehavior { get; set; }
        public ReferenceCollection TargetRoles { get; set; }

        public bool AllowDeploymentsToNoTargets { get; set; }

        public bool ExcludeUnhealthyTargets { get; set; }

        public ProjectConnectivityPolicy()
        {
            TargetRoles = new ReferenceCollection();
        }
    }
}