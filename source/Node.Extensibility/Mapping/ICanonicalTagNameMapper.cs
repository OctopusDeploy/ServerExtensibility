namespace Octopus.Node.Extensibility.Mapping
{
    public interface ICanonicalTagNameMapper
    {
        string GetTagIdFromCanonicalTagName(string canonicalTagName);
        string GetCanonicalTagNameFromTagId(string tagId);
    }
}