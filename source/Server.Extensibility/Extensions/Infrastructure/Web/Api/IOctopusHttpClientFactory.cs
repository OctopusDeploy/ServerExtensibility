using System;
using System.Net.Http;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IOctopusHttpClientFactory
    {
        HttpClient CreateClient();
    }
}