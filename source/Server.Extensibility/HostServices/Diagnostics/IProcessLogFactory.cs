using System;
using Octopus.Diagnostics;
using Octopus.Server.MessageContracts.Diagnostics;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface IProcessLogFactory<TProcessLog>
        where TProcessLog : IProcessLog<TProcessLog>
    {
        TProcessLog Get(CorrelationId correlationId);

        /// <summary>
        /// Opens a new child block for logging.
        /// </summary>
        /// <param name="processLog">Parent command log</param>
        /// <param name="messageText">Title of the new block.</param>
        /// <returns>A child <see cref="IProcessLog" />.</returns>
        TProcessLog CreateBlock(TProcessLog processLog, string messageText);

        /// <summary>
        /// Opens a new child block for logging.
        /// </summary>
        /// <param name="processLog">Parent command log</param>
        /// <param name="messageFormat">Format string for the message.</param>
        /// <param name="args">Arguments for the format string.</param>
        /// <returns>A child <see cref="IProcessLog" />.</returns>
        [StringFormatMethod("messageFormat")]
        TProcessLog CreateBlock(TProcessLog processLog, string messageFormat, params object[] args);

        /// <summary>
        /// Completes the given logging block
        /// </summary>
        /// <param name="processLog"></param>
        void Finish(TProcessLog processLog);
    }
}