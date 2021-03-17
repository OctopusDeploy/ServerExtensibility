using System;
using Octopus.Diagnostics;

namespace Octopus.Server.Extensibility.HostServices.Mapping
{
    public interface ICanonicalTagNameMapper
    {
        string GetTagIdFromCanonicalTagName(string canonicalTagName);
        string? GetCanonicalTagNameFromTagId(string canonicalTagId, ILog log);
    }
}