namespace Octopus.Server.Extensibility.Metadata
{
    public class ConnectivityCheck
    {
        public string Title { get; set; }
        public string Url { get; set; }

        public string[] DependsOnPropertyNames { get; set; }
    }
}