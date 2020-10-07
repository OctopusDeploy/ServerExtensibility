using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesCSS
    {
        IEnumerable<string> GetCSSUris();
    }
}