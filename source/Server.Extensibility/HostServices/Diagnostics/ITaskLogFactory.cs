using System;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface ITaskLogFactory
    {
        ITaskLog Create(string correlationId, string[]? sensitiveValues = null);
        void Finish(string correlationId);
    }
}