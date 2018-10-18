using System;

namespace Octopus.Server.Extensibility.Metadata
{
    public interface IGenerateMetadata
    {
        Metadata GetMetadata(Type objectType);

        Metadata GetMetadata<T>();
    }
}