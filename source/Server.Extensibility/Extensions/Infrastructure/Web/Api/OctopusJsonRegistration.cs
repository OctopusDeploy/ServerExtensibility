using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class OctopusJsonRegistration<TResource> : BaseResponseRegistration
    {
        public OctopusJsonRegistration(HttpStatusCode statusCode = HttpStatusCode.OK, string descriptionSuffix = "resource returned") : base(statusCode, $"{FriendlyId(typeof(TResource))} {descriptionSuffix}")
        {
            Type = typeof(TResource);

        }

        public Type Type { get; }

        public IOctoResponseProvider Response(TResource model) => new WrappedResponse(new OctoDataResponse(model));

        static string FriendlyId(Type type, bool fullyQualified = false)
        {
            var typeName = fullyQualified
                ? FullNameSansTypeParameters(type).Replace("+", ".")
                : type.Name;

            if (type.GetTypeInfo().IsGenericType)
            {
                var genericArgumentIds = type.GetGenericArguments()
                                             .Select(t => FriendlyId(t, fullyQualified))
                                             .ToArray();

                return new StringBuilder(typeName)
                       .Replace(string.Format("`{0}", genericArgumentIds.Count()), string.Empty)
                       .Append(string.Format("_of_{0}", string.Join(",", genericArgumentIds).TrimEnd(',')))
                       .ToString();
            }

            return typeName;
        }
        static string FullNameSansTypeParameters(Type type)
        {
            var fullName = type.FullName;
            var chopIndex = fullName.IndexOf("[[");
            return (chopIndex == -1) ? fullName : fullName.Substring(0, chopIndex);
        }
    }
}