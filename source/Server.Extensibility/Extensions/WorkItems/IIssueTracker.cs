namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IIssueTracker
    {
        /// <summary>
        /// Descriptive name for the issue tracker
        /// </summary>
        string IssueTrackerName { get; }

        /// <summary>
        /// Gets whether the issue tracker is currently enabled
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// The CommentParser of this tracker, used by the build extensions to identify which baseUrl to prefix the linkUrl with.
        /// </summary>
        string CommentParser { get; }

        /// <summary>
        /// The base Url to prefix the work item's linkUrl with.
        /// </summary>
        string? BaseUrl { get; }
    }
}
