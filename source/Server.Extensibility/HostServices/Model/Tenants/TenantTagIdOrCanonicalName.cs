using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Tenants
{
    public class TenantTagIdOrCanonicalName : CaseInsensitiveStringTinyType
    {
        public TenantTagIdOrCanonicalName(string value) : base(value)
        {
        }
    }
}