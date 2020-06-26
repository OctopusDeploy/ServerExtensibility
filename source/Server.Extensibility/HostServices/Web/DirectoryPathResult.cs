namespace Octopus.Server.Extensibility.HostServices.Web
{
    public class DirectoryPathResult
    {
        private DirectoryPathResult(bool isValid, string path, string invalidReason)
        {
            IsValid = isValid;
            Path = path;
            InvalidReason = invalidReason;
        }

        public bool IsValid { get; }
        public string Path { get; }

        public string InvalidReason { get; }

        public static DirectoryPathResult Success(string directoryPath)
        {
            return new DirectoryPathResult(true, directoryPath, null);
        }

        public static DirectoryPathResult Invalid(string reason)
        {
            return new DirectoryPathResult(false, null, reason);
        }
    }
}