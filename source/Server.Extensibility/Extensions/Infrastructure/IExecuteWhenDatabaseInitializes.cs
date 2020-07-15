using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure
{
    public interface IExecuteWhenDatabaseInitializes
    {
        void PreExecute();
        void Execute();
        void PostExecute();
    }
}