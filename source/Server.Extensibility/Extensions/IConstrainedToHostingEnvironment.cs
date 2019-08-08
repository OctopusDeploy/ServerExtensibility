namespace Octopus.Server.Extensibility.Extensions
{
    public interface IConstrainedToHostingEnvironment
    {
        OctopusHostingEnvironment HostingEnvironment { get; }
    }
}