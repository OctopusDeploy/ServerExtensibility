using System;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IEndpointInvocation
    {
    }

    public class AnonymousEndpointInvocation : IEndpointInvocation
    {
    }

    public class AnonymousWhenEnabledEndpointInvocation<TConfigurationStore> : IEndpointInvocation
        where TConfigurationStore : IExtensionConfigurationStore
    {
    }

    public class SecuredEndpointInvocation : IEndpointInvocation
    {
    }

    public class SecuredWhenEnabledEndpointInvocation<TConfigurationStore> : IEndpointInvocation
        where TConfigurationStore : IExtensionConfigurationStore
    {
    }

    public class SecuredAdministratorWhenEnabledEndpointInvocation<TConfigurationStore> : IEndpointInvocation
        where TConfigurationStore : IExtensionConfigurationStore
    {
    }
}