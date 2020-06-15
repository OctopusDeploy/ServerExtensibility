using Octopus.TinyTypes;

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
        }
    }
}