using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Tenants
{
    public class TenantTag : CaseInsensitiveStringTinyType
    {
        public TenantTag(string value) : base(value)
        {
        }
    }
}