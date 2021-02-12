using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Accounts
{
    public class AccountId : CaseInsensitiveStringTinyType, IIdTinyType
    {
        public AccountId(string value) : base(value)
        {
        }
    }
}