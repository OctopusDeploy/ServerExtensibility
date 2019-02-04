using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public interface IPackageReferenceCollection : ICollection<IPackageReference>
    {
        IPackageReference PrimaryPackage { get; }

        bool HasPrimaryPackage { get; }
    }
}