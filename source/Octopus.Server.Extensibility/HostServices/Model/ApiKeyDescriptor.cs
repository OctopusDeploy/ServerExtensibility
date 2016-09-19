using System;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class ApiKeyDescriptor
    {
        public ApiKeyDescriptor(string purpose)
        {
            Purpose = purpose;
        }

        public ApiKeyDescriptor(string purpose, string apiKey)
        {
            Purpose = purpose;
            ApiKey = apiKey;
        }

        public string Purpose { get; private set; }
        public string ApiKey { get; set; }
    }
}