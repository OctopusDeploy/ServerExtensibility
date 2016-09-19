using System;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public interface IOverridableId : IId
    {
        void SetId(string id);
    }
}