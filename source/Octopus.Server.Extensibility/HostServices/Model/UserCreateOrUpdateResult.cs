using System;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class UserCreateOrUpdateResult
    {
        public UserCreateOrUpdateResult(IUser user)
        {
            Succeeded = user != null;
            User = user;
        }

        public UserCreateOrUpdateResult(string failureReason)
        {
            if (string.IsNullOrWhiteSpace(failureReason))
                throw new ArgumentException("User creation failure reason not provided", nameof(failureReason));
            FailureReason = failureReason;
        }

        public bool Succeeded { get; private set; }
        public IUser User { get; private set; }
        public string FailureReason { get; private set; }
    }
}