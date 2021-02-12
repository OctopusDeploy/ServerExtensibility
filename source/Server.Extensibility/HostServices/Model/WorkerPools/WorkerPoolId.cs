using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.WorkerPools
{
    public class WorkerPoolId : CaseInsensitiveStringTinyType, IIdTinyType
    {
        public WorkerPoolId(string value) : base(value)
        {
        }
    }
}