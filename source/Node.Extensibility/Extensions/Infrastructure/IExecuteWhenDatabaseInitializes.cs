namespace Octopus.Node.Extensibility.Extensions.Infrastructure
{
    public interface IExecuteWhenDatabaseInitializes
    {
        void PreExecute();
        void Execute();
        void PostExecute();
    }
}