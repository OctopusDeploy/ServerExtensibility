using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public interface IDeploymentEnvironment : IDocument, IHaveSpace
    {
        string Description { get; }
        int SortOrder { get; }
        bool UseGuidedFailure { get; }

        bool AllowDynamicInfrastructure { get; }

        IList<ExtensionSettingsValues> ExtensionSettings { get; set; }
    }
}