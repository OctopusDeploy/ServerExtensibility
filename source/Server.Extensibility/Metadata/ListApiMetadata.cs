namespace Octopus.Server.Extensibility.Metadata
{
    public class ListApiMetadata
    {
        public ListApiMetadata(string selectMode, string apiEndpoint)
        {
            SelectMode = selectMode;
            ApiEndpoint = apiEndpoint;
        }

        public string SelectMode { get; }

        public string ApiEndpoint { get; }
    }
}