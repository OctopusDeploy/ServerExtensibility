using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IConfigurationDocumentMapper
    {
        Type GetTypeToMap();
    }
}