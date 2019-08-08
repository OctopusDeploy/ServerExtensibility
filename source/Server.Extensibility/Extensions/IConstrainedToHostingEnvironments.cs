using Octopus.Server.Extensibility.HostServices.Licensing;

namespace Octopus.Server.Extensibility.Extensions
{
    public interface IConstrainedToHostingEnvironments
    {
        OctopusHostingEnvironments[] HostingEnvironments { get; }
    }
}