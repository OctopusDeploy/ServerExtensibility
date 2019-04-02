namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface ICommitLinkMapper
    {
        string VcsType { get; }
        bool IsEnabled { get; }

        string Map(string vcsRoot, string commitNumber);
    }
}