namespace Octopus.Server.Extensibility.Extensions
{
    public interface IAvailableInHostingEnvironments
    {
        OctopusHostingEnvironments[] HostingEnvironments { get; }
    }
}