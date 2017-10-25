namespace Octopus.Node.Extensibility.Mapping
{
    public interface IResourceMappingContext
    {
        ICanonicalTagNameMapper CanonicalTagNameMapper { get; }
        ICanonicalActionNameMapper CanonicalActionNameMapper { get; }
    }
}