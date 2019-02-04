using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IActionTemplateParameter
    {
        string Id { get; set; }
        string Name { get; set; }
        string Label { get; set; }
        string HelpText { get; set; }
        PropertyValue DefaultValue { get; set; }
        IDictionary<string, string> DisplaySettings { get; set; }
    }
}