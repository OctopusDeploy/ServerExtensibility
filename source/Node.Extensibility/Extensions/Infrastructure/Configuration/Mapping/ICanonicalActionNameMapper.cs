using System.Collections.Generic;
using Nevermore.Contracts;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface ICanonicalActionNameMapper
    {
        List<string> GetNamesFromIds(string projectId, ReferenceCollection actionIds);
        List<string> GetIdsFromReferences(string projectId, ReferenceCollection actionReferences);
    }
}