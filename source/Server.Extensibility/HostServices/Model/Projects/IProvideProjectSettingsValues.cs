using System;
using Octopus.Server.MessageContracts.Features.Projects;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IProvideProjectSettingsValues
    {
        T GetSettings<T>(string extensionId, ProjectId projectId);
    }
}