using Octopus.Server.Extensibility.HostServices.Model.ServerTasks;

namespace Octopus.Server.Extensibility.Extensions.Tasks
{
    public interface ITaskPrecondition
    {
        PreconditionCheckResult Check(IServerTask task);
    }

    public enum TaskPreconditionExecutionOutcome
    {
        RunNow,
        Wait,
        Fail
    }

    public class PreconditionCheckResult
    {
        public PreconditionCheckResult(TaskPreconditionExecutionOutcome executionOutcome, string reason = null)
        {
            ExecutionOutcome = executionOutcome;
            Reason = reason;
        }

        public TaskPreconditionExecutionOutcome ExecutionOutcome { get; }
        public string Reason { get; }
    }
}