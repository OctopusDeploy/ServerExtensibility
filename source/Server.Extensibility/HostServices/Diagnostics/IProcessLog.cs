﻿using System;
using System.Linq;
using Octopus.Diagnostics;
using Octopus.Server.MessageContracts.Diagnostics;
using Octopus.Server.MessageContracts.Features.Projects;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface IProcessLog<T> : ILog
        where T : IProcessLog<T>
    {
        /// <summary>
        /// The root correlationId for this log. Used to locate the log file.
        /// </summary>
        RootCorrelationId RootCorrelationId { get; }

        /// <summary>
        /// Creates a child context with the same correlationId and additional sensitive values.
        /// </summary>
        /// <param name="sensitiveValues">Additional sensitive values.</param>
        /// <returns>A new child log</returns>
        T ChildContext(string[] sensitiveValues);
    }
}