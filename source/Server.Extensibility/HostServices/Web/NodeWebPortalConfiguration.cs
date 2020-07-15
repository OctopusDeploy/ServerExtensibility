using System;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public class NodeWebPortalConfiguration
    {
        public string[] ListenPrefixes { get; set; } = Array.Empty<string>();
        public bool ForceSSL { get; set; }
    }
}