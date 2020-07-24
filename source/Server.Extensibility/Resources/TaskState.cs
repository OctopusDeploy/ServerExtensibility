using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Resources
{
    /// <summary>
    ///     Represents the different states a task goes through.
    /// </summary>
    public enum TaskState
    {
        Queued = 1,
        Executing = 2,
        Failed = 3,
        Canceled = 4,
        TimedOut = 5,
        Success = 6,
        Cancelling = 8
    }

    public class TaskStates
    {
        public static IReadOnlyList<TaskState> CompletedUnsuccessfully =
            new[] { TaskState.Failed, TaskState.TimedOut, TaskState.Canceled };

        public static IReadOnlyList<TaskState> Completed = new[]
            { TaskState.Success, TaskState.Failed, TaskState.TimedOut, TaskState.Canceled };

        public static IReadOnlyList<TaskState> Incomplete = new[]
            { TaskState.Queued, TaskState.Executing, TaskState.Cancelling };

        public static IReadOnlyList<TaskState> Running = new[] { TaskState.Executing, TaskState.Cancelling };
    }
}