using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IActionTemplateParameter
    {
        string Id { get; }
        string Name { get; }
        string Label { get; }
        string HelpText { get; }
        PropertyValue DefaultValue { get; }
        IDictionary<string, string> DisplaySettings { get; }
    }
}