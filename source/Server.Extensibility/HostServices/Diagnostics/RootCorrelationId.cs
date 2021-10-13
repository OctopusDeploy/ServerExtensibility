using System;
using System.Linq;
using Octopus.Server.MessageContracts.Diagnostics;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public class RootCorrelationId : CorrelationId
    {
        RootCorrelationId(string rootCorrelationId) : base(rootCorrelationId)
        {
            if (rootCorrelationId.Contains('/'))
                throw new ArgumentException("Root correlation IDs can not contain forward slashes");
        }

        public static RootCorrelationId CreateFromCorrelationId(CorrelationId correlationId)
            => new ((correlationId.Value.Split('/').FirstOrDefault() ?? correlationId.Value).ToLowerInvariant());

        public string GetDocumentId()
        {
            var underscore = Value.IndexOf("_", StringComparison.Ordinal);
            if (underscore < 0)
                return Value;
            return Value.Substring(0, underscore);
        }
    }
}