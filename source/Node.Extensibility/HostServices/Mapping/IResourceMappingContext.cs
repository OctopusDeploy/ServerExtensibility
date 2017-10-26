namespace Octopus.Node.Extensibility.HostServices.Mapping
{
    public interface IResourceMappingContext
    {
        ICanonicalTagNameMapper CanonicalTagNameMapper { get; }
        ICanonicalActionNameMapper CanonicalActionNameMapper { get; }
    }
}