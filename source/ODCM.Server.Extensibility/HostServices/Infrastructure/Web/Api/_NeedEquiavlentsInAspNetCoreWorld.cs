using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;

namespace ODCM.Server.Extensibility.HostServices.Infrastructure.Web.Api
{
    //TODO: aspnetcore equiavlent needed for 
    public interface ISerializer
    {
        /// <summary>
        /// Whether the serializer can serialize the content type
        /// </summary>
        /// <param name="contentType">Content type to serialise</param>
        /// <returns>True if supported, false otherwise</returns>
        bool CanSerialize(string contentType);

        /// <summary>
        /// Gets the list of extensions that the serializer can handle.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> of extensions if any are available, otherwise an empty enumerable.</value>
        IEnumerable<string> Extensions { get; }

        /// <summary>
        /// Serialize the given model with the given contentType
        /// </summary>
        /// <param name="contentType">Content type to serialize into</param>
        /// <param name="model">Model to serialize</param>
        /// <param name="outputStream">Output stream to serialize to</param>
        /// <returns>Serialised object</returns>
        void Serialize<TModel>(string contentType, TModel model, Stream outputStream);
    }

    public interface IResponseFormatter //: IHideObjectMembers
    {
        /// <summary>Gets all serializers currently registered</summary>
        IEnumerable<ISerializer> Serializers { get; }
        /// <summary>
        /// Gets the context for which the response is being formatted.
        /// </summary>
        /// <value>A <see cref="T:Nancy.NancyContext" /> instance.</value>
        HttpContext Context { get; }
        /// <summary>Gets the root path of the application.</summary>
        /// <value>A <see cref="T:System.String" /> containing the root path.</value>
        string RootPath { get; }
    }
}
