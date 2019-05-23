using Octopus.Data.Resources.Attributes;

namespace Octopus.Server.Extensibility.Metadata
{
    public class PropertyApplicability {
        public PropertyApplicabilityMode Mode { get; set; }
        public string DependsOnPropertyName { get; set; }
        public object DependsOnPropertyValue { get; set; }
    }
}