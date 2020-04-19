using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public interface IDeploymentEnvironment : IHaveSpace
    {
        string Description { get; }
        int SortOrder { get; }
        bool UseGuidedFailure { get; }

        bool AllowDynamicInfrastructure { get; }

        IList<ExtensionSettingsValues> ExtensionSettings { get; set; }
    }
}