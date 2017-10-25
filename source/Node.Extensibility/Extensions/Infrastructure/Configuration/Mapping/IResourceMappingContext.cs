namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IResourceMappingContext
    {
        ICanonicalTagNameMapper CanonicalTagNameMapper { get; }
        ICanonicalActionNameMapper CanonicalActionNameMapper { get; }
    }
}