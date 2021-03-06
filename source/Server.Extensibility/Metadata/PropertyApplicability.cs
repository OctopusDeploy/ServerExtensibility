using System;
using Octopus.Server.MessageContracts.Attributes;

namespace Octopus.Server.Extensibility.Metadata
{
    public class PropertyApplicability
    {
        public PropertyApplicability(PropertyApplicabilityMode mode, string dependsOnPropertyName)
        {
            Mode = mode;
            DependsOnPropertyName = dependsOnPropertyName;
        }

        public PropertyApplicabilityMode Mode { get; }
        public string DependsOnPropertyName { get; }
        public object? DependsOnPropertyValue { get; set; }
    }
}