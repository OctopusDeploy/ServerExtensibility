namespace Octopus.Server.Extensibility.HostServices.Model.Variables
{
    public class LibraryVariableSetSnapshot
    {
        public LibraryVariableSetSnapshot(string libraryVariableSetId, string variableSetSnapshotId)
        {
            VariableSetSnapshotId = variableSetSnapshotId;
            LibraryVariableSetId = libraryVariableSetId;
        }

        public string LibraryVariableSetId { get; private set; }
        public string VariableSetSnapshotId { get; private set; }
    }
}