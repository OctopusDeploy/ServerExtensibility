namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public static class OctoResponseProviderExtensionMethods
    {
        public static IOctoResponseProvider WithHeader(this IOctoResponseProvider responseProvider, string header, string value)
            => new BaseResponseRegistration.WrappedResponse(responseProvider.Response.WithHeader(header, new []{ value }));
    }
}