using System;

namespace Octopus.Server.Extensibility.HostServices.Mapping
{
    public interface ICanonicalTagNameMapper
    {
        string GetTagIdFromCanonicalTagName(string canonicalTagName);
        string GetCanonicalTagNameFromTagId(string tagId);
    }
}