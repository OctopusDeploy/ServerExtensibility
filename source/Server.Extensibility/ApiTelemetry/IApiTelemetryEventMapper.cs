using System;

namespace Octopus.Server.Extensibility.ApiTelemetry
{
    public interface IApiTelemetryEventMapper
    {
        /// <summary>
        /// Gets the command/request type that this mapper handles
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Map the given instance to an output structure that will be used as part of an ApiTelemetryEvent.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object Map(object value);
    }
}
