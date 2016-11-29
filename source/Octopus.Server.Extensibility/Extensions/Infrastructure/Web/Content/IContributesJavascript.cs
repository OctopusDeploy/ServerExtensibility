using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesJavascript
    {
        IEnumerable<string> GetJavascriptUris();

        [ObsoleteEx(RemoveInVersion = "2.0", TreatAsErrorFromVersion = "2.0", ReplacementTypeOrMember = "GetJavascriptUris")]
        IEnumerable<string> GetJavascriptUris(string requestDirectoryPath);
    }
}