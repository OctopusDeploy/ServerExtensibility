using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Accounts
{
    public class AccountName : CaseInsensitiveStringTinyType
    {
        public AccountName(string value) : base(value)
        {
        }
    }
}