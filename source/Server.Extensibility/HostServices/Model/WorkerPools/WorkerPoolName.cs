using System;
using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.WorkerPools
{
    public class WorkerPoolName : CaseInsensitiveStringTinyType
    {
        public WorkerPoolName(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value),
                    "Worker pool IDs or Names should never be null or empty. If the value you want to communicate is null/empty/whitespace then " +
                    "just pass a null rather than a tiny type wrapping it.");
        }
    }
}