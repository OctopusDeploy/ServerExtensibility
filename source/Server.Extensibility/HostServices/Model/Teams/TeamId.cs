using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Teams
{
    public class TeamId : CaseInsensitiveStringTinyType
    {
        public TeamId(string value) : base(value)
        {
        }
    }
}