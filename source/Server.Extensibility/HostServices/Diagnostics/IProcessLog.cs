using Octopus.Diagnostics;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface IProcessLog : ILog
    {
        /// <summary>
        /// Creates a child context with the same correlationId and additional sensitive values.
        /// </summary>
        /// <param name="sensitiveValues">Additional sensitive values.</param>
        /// <returns>A new child log</returns>
        IProcessLog ChildContext(string[] sensitiveValues);
    }
}