using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IProvideProjectSettingsValues
    {
        IDictionary<string, object> GetValues(string extensionId);
    }
}