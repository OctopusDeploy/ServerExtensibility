using System.Collections.Generic;
using Newtonsoft.Json;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class AutoDeployReleaseOverride
    {
        public string EnvironmentId { get; }
        public string TenantId { get; }
        public string ReleaseId { get; }

        public AutoDeployReleaseOverride(string environmentId, string releaseId)
            : this(environmentId, null, releaseId)
        {
        }

        [JsonConstructor]
        public AutoDeployReleaseOverride(string environmentId, string tenantId, string releaseId)
        {
            EnvironmentId = environmentId;
            TenantId = tenantId;
            ReleaseId = releaseId;
        }

        sealed class EnvironmentIdTenantIdEqualityComparer : IEqualityComparer<AutoDeployReleaseOverride>
        {
            public bool Equals(AutoDeployReleaseOverride x, AutoDeployReleaseOverride y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.EnvironmentId, y.EnvironmentId) && string.Equals(x.TenantId, y.TenantId);
            }

            public int GetHashCode(AutoDeployReleaseOverride obj)
            {
                unchecked
                {
                    return ((obj.EnvironmentId?.GetHashCode() ?? 0) * 397) ^ (obj.TenantId?.GetHashCode() ?? 0);
                }
            }
        }

        public static IEqualityComparer<AutoDeployReleaseOverride> EnvironmentIdTenantIdComparer { get; } = new EnvironmentIdTenantIdEqualityComparer();
    }
}