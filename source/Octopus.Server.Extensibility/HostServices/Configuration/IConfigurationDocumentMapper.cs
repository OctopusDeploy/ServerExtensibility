using System;

namespace Octopus.Server.Extensibility.HostServices.Configuration
{
    public interface IConfigurationDocumentMapper
    {
        Type GetTypeToMap();
    }
}