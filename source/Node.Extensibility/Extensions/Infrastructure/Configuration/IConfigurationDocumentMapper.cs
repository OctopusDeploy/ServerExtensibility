using System;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IConfigurationDocumentMapper
    {
        Type GetTypeToMap();
    }
}