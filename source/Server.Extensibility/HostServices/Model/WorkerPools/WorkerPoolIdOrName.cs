using System;

namespace Octopus.Server.Extensibility.HostServices.Model.WorkerPools
{
    /// <summary>
    ///     This is a Poor Man's Either&lt;WorkerPoolId, WorkerPoolName&gt; but given that we actually don't know what it
    ///     is at this point and have to look it up to find out, we can't even use an Either&lt;,&gt; to wrap it nicely.
    /// </summary>
    public class WorkerPoolIdOrName : CaseInsensitiveStringTinyType
    {
        public WorkerPoolIdOrName(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value),
                    "Worker pool IDs or Names should never be null or empty. If the value you want to communicate is null/empty/whitespace then " +
                    "just pass a null rather than a tiny type wrapping it.");
        }
    }
}