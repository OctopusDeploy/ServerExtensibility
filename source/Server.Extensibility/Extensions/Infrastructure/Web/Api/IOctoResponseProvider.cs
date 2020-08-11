using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IOctoResponseProvider
    {
        OctoResponse Response { get; }

        IOctoResponseProvider WithCookie(OctoCookie cookie);
        IOctoResponseProvider WithHeader(string name, IEnumerable<string> value);
    }
}