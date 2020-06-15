using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.WorkerPools
{
    public class WorkerPoolName : CaseInsensitiveStringTinyType
    {
        public WorkerPoolName(string value) : base(value)
        {
        }
    }
}