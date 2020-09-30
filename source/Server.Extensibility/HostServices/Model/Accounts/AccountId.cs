using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Accounts
{
    public class AccountId : CaseInsensitiveStringTinyType
    {
        public AccountId(string value) : base(value)
        {
        }
    }
}