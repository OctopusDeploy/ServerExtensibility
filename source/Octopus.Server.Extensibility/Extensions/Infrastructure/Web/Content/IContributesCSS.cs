using System.Collections;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesCSS
    {
        IEnumerable<string> GetCSSUris();

        [ObsoleteEx(RemoveInVersion = "2.0", TreatAsErrorFromVersion = "2.0", ReplacementTypeOrMember = "GetJavascriptUris")]
        IEnumerable<string> GetCSSUris(string requestDirectoryPath);
    }
}