namespace Octopus.Node.Extensibility.Metadata
{
    public interface IGenerateMetadata
    {
        Metadata GetMetadata<T>(T config);

        Metadata GetMetadata<T>();
    }
}