using System;

namespace Octopus.Node.Extensibility.Metadata
{
    public interface IGenerateMetadata
    {
        Metadata GetMetadata(Type objectType);

        Metadata GetMetadata<T>();
    }
}