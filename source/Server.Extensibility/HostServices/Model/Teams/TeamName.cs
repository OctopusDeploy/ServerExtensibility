using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Teams
{
    public class TeamName : CaseInsensitiveStringTinyType
    {
        public TeamName(string value) : base(value)
        {
        }
    }
}