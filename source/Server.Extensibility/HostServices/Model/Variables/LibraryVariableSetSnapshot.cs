using System;

namespace Octopus.Server.Extensibility.HostServices.Model.Variables
{
    public class LibraryVariableSetSnapshot
    {
        public LibraryVariableSetSnapshot(string libraryVariableSetId, string variableSetSnapshotId)
        {
            VariableSetSnapshotId = variableSetSnapshotId;
            LibraryVariableSetId = libraryVariableSetId;
        }

        public string LibraryVariableSetId { get; }
        public string VariableSetSnapshotId { get; }
    }
}