using System;
using System.Net.Http;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IOctopusHttpClientProvider
    {
        /// <summary>
        /// The HttpClientHandler instance is a singleton, so consumers of this object should not dispose it
        /// </summary>
        HttpClientHandler HttpClientHandler { get; }
        
        /// <summary>
        /// The HttpClient instance is a singleton, so consumers of this object should not dispose it
        /// </summary>
        HttpClient HttpClient { get; }
    }
}