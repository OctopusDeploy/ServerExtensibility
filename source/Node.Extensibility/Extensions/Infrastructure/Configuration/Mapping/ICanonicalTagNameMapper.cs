namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface ICanonicalTagNameMapper
    {
        string GetTagIdFromCanonicalTagName(string canonicalTagName);
        string GetCanonicalTagNameFromTagId(string tagId);
    }
}