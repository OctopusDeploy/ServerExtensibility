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
        public PreconditionCheckResult(TaskPreconditionExecutionOutcome executionOutcomeOutcome, string reason = null)
        {
            ExecutionOutcomeOutcome = executionOutcomeOutcome;
            Reason = reason;
        }

        public TaskPreconditionExecutionOutcome ExecutionOutcomeOutcome { get; }
        public string Reason { get; }
    }
}