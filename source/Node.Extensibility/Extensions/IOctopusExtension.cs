using Autofac;

namespace Octopus.Node.Extensibility.Extensions
{
    public interface IOctopusExtension
    {
        void Load(ContainerBuilder builder);
    }
}
