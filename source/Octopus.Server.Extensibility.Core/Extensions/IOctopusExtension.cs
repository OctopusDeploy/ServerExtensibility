using System;
using Autofac;

namespace Octopus.Server.Extensibility.Extensions
{
    public interface IOctopusExtension
    {
        void Load(ContainerBuilder builder);
    }
}
