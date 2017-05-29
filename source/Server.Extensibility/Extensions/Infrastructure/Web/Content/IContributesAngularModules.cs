using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Content
{
    /// <summary>
    /// Implemented by extensions that are providing their own Angular Modules.  The module's JS code
    /// should be returned by implementing <see cref="IContributesJavascript"/>, then the names returned
    /// here identify the module names that need to then be included as dependencies for the Octopus App.
    /// </summary>
    public interface IContributesAngularModules
    {
        IEnumerable<string> GetAngularModuleNames();
    }
}