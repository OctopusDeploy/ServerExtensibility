using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Accounts
{
    public class AccountIdOrName : CaseInsensitiveStringTinyType, IIdOrNameTinyType
    {
        public AccountIdOrName(string value) : base(value)
        {
        }
    }
}