using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Tenants
{
    public class TenantTagIdOrName : CaseInsensitiveStringTinyType
    {
        public TenantTagIdOrName(string value) : base(value)
        {
        }
    }
}