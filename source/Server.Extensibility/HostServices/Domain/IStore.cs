using System;
using Octopus.Data.Model;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Domain
{
    public interface IStore<out TDocument>
        where TDocument : IId
    {
        TDocument Get(string id);
    }

    public interface IStore<out TDocument, out TId>
        where TDocument : IDocument<TId>
        where TId : CaseInsensitiveStringTinyType
    {
        TDocument Get(string id);
    }
}