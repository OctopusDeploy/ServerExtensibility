namespace Octopus.Server.Extensibility.HostServices.Web
{
    public class NodeWebPortalConfiguration
    {
        public string[] ListenPrefixes { get; set; }
        public bool ForceSSL { get; set; }
    }
}