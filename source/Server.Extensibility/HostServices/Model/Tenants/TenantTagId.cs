using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Tenants
{
    public class TenantTagId : CaseInsensitiveStringTinyType
    {
        public TenantTagId(string value) : base(value)
        {
        }
    }
}