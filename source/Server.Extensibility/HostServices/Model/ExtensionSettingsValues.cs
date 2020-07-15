using System;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class ExtensionSettingsValues
    {
        public string ExtensionId { get; set; } = string.Empty;
        public object? Values { get; set; }
    }
}