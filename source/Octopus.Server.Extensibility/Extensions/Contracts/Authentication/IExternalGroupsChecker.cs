using System;
using System.Collections.Generic;
using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.Extensions.Contracts.Authentication
{
    public interface IExternalGroupsChecker
    {
        /// <summary>
        /// Checks the external group store and updates the user's external security groups.  May run
        /// the check on a background thread and return null in the meantime.
        /// </summary>
        /// <param name="user">The user to check groups for</param>
        /// <param name="forceRefresh">Forces an immediate refresh, on the foreground thread</param>
        /// <returns>The list of security group "ids".  For AD these would be sids, for OAuth these may be roles or sids</returns>
        HashSet<string> EnsureExternalSecurityGroupsAreUpToDate(IUser user, bool forceRefresh = false);
    }
}