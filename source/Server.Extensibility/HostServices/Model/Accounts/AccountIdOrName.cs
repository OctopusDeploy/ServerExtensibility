using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Accounts
{
    public class AccountIdOrName : CaseInsensitiveStringTinyType
    {
        public AccountIdOrName(string value) : base(value)
        {
        }
    }
}