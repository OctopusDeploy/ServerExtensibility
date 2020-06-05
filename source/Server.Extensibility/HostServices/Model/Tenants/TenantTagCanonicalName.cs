using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Tenants
{
    public class TenantTagCanonicalName : CaseInsensitiveStringTinyType
    {
        public TenantTagCanonicalName(string value) : base(value)
        {
        }
    }
}