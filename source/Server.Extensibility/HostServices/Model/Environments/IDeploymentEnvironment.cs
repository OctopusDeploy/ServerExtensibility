using System;
using System.Collections.Generic;
using Octopus.Data.Model;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public interface IDeploymentEnvironment : IDocument<DeploymentEnvironmentId>, IHaveSpace
    {
        string Description { get; }
        int SortOrder { get; }
        bool UseGuidedFailure { get; }

        bool AllowDynamicInfrastructure { get; }

        IList<ExtensionSettingsValues> ExtensionSettings { get; set; }
    }
}