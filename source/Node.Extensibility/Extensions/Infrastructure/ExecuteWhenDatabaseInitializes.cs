namespace Octopus.Node.Extensibility.Extensions.Infrastructure
{
    public abstract class ExecuteWhenDatabaseInitializes : IExecuteWhenDatabaseInitializes
    {
        public virtual void PreExecute()
        {
        }

        public abstract void Execute();

        public virtual void PostExecute()
        {
        }
    }
}