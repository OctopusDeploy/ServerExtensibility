using System;

namespace Octopus.Server.Extensibility.Metadata
{
    public class ConnectivityCheck
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public string[] DependsOnPropertyNames { get; set; } = Array.Empty<string>();
    }
}