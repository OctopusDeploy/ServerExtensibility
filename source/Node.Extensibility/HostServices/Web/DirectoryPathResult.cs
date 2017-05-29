namespace Octopus.Node.Extensibility.HostServices.Web
{
    public class DirectoryPathResult
    {
        private DirectoryPathResult(bool isValid, string path, string invalidReason)
        {
            IsValid = isValid;
            Path = path;
            InvalidReason = invalidReason;
        }

        public bool IsValid { get; private set; }
        public string Path { get; private set; }

        public string InvalidReason { get; private set; }

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