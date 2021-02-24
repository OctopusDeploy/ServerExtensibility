using System;
using Octopus.Diagnostics;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface ITaskLog : ILog, IDisposable
    {
        bool IsVerboseEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsTraceEnabled { get; }
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Opens a new child block for logging.
        /// </summary>
        /// <param name="messageText">Title of the new block.</param>
        /// <returns>A child <see cref="ITaskLog" />.</returns>
        ITaskLog CreateBlock(string messageText);

        /// <summary>
        /// Opens a new child block for logging.
        /// </summary>
        /// <param name="messageFormat">Format string for the message.</param>
        /// <param name="args">Arguments for the format string.</param>
        /// <returns>A child <see cref="ITaskLog" />.</returns>
        [StringFormatMethod("messageFormat")]
        ITaskLog CreateBlock(string messageFormat, params object[] args);

        /// <summary>
        /// Creates a child context with the same correlationId and additional sensitive values.
        /// </summary>
        /// <param name="sensitiveValues">Additional sensitive values.</param>
        /// <returns>A new child task log</returns>
        ITaskLog ChildContext(string[] sensitiveValues);

        /// <summary>
        /// Plans a new block of output that will be used in the future for grouping child blocks for logging.
        /// </summary>
        /// <param name="messageText">Title of the new block.</param>
        /// <returns>A child <see cref="ITaskLog" />.</returns>
        ITaskLog PlanGroupedBlock(string messageText);

        /// <summary>
        /// Plans a new block of log output that will be used in the future. This is typically used for high-level log
        /// information, such as the steps in a big deployment process.
        /// </summary>
        /// <param name="messageText">Title of the new block.</param>
        /// <returns>A child <see cref="ITaskLog" />.</returns>
        ITaskLog PlanFutureBlock(string messageText);

        /// <summary>
        /// Plans a new block of log output that will be used in the future. This is typically used for high-level log
        /// information, such as the steps in a big deployment process.
        /// </summary>
        /// <param name="messageFormat">Format string for the message.</param>
        /// <param name="args">Arguments for the format string.</param>
        /// <returns>A child <see cref="ITaskLog" />.</returns>
        [StringFormatMethod("messageFormat")]
        ITaskLog PlanFutureBlock(string messageFormat, params object[] args);

        /// <summary>
        /// Marks the current block as abandoned. Abandoned blocks won't be shown in the task log.
        /// </summary>
        void Abandon();

        /// <summary>
        /// If a block was previously abandoned using <see cref="Abandon" />, calling <see cref="Reinstate" /> will un-abandon
        /// it.
        /// </summary>
        void Reinstate();

        /// <summary>
        /// Marks the current block as finished. If there were any errors, it will be finished with errors. If there were no
        /// errors, it will be assumed to be successful.
        /// </summary>
        void Finish();

        bool IsEnabled(LogCategory category);

        void UpdateProgress(int progressPercentage, string messageText);

        [StringFormatMethod("messageFormat")]
        void UpdateProgressFormat(int progressPercentage, string messageFormat, params object[] args);
    }
}