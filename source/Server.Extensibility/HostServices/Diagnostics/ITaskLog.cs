using System;
using Octopus.Diagnostics;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface ITaskLog : ILog
    {
        bool IsVerboseEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsTraceEnabled { get; }
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Creates a child context with the same correlationId and additional sensitive values.
        /// </summary>
        /// <param name="sensitiveValues">Additional sensitive values.</param>
        /// <returns>A new child task log</returns>
        ITaskLog ChildContext(string[] sensitiveValues);

        /// <summary>
        /// Marks the current block as abandoned. Abandoned blocks won't be shown in the task log.
        /// </summary>
        void Abandon();

        /// <summary>
        /// If a block was previously abandoned using <see cref="Abandon" />, calling <see cref="Reinstate" /> will un-abandon
        /// it.
        /// </summary>
        void Reinstate();

        bool IsEnabled(LogCategory category);

        void UpdateProgress(int progressPercentage, string messageText);

        [StringFormatMethod("messageFormat")]
        void UpdateProgressFormat(int progressPercentage, string messageFormat, params object[] args);
    }
}