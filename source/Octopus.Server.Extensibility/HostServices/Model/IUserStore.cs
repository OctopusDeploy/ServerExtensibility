using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public interface IUserStore
    {
        UserCreateOrUpdateResult GetOrCreateUser(string username, string displayName, string emailAddress, string externalId, ApiKeyDescriptor apiKeyDescriptor = null);

        IUser GetById(string userId);
        IUser GetByUsername(string username);
        IUser GetByIdentificationToken(Guid identificationToken);

        UserCreateOrUpdateResult Create(string username, string displayName, string emailAddress, string externalId, ApiKeyDescriptor apiKeyDescriptor = null, string id = null, string password = null, bool isService = false, bool generateRandomPasswordOnCreate = false);

        UserCreateOrUpdateResult CreateOrUpdate(
            string username,
            string displayName, 
            string emailAddress, 
            string externalId, 
            ApiKeyDescriptor apiKeyDescriptor, 
            bool generateRandomPasswordOnCreate, 
            string password,
            bool isService,
            string[] externalGroups);

        void EnableUser(string userId);
        void DisableUser(string userId);

        void UpdateUsersExternalGroups(IUser user, HashSet<string> groups);
    }
}