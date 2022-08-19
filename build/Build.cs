using System;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.OctoVersion;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    const string CiBranchNameEnvVariable = "OCTOVERSION_CurrentBranch";

    readonly Configuration Configuration = Configuration.Release;

    [Solution] readonly Solution Solution;
    
    [Parameter("Whether to auto-detect the branch name - this is okay for a local build, but should not be used under CI.")] 
    readonly bool AutoDetectBranch = IsLocalBuild;
    
    [Parameter("Branch name for OctoVersion to use to calculate the version number. Can be set via the environment variable " + CiBranchNameEnvVariable + ".", Name = CiBranchNameEnvVariable)]
    string BranchName { get; set; }
    

    [OctoVersion(BranchParameter = nameof(BranchName), AutoDetectBranchParameter = nameof(AutoDetectBranch), Framework = "net6.0")] 
    public OctoVersionInfo OctoVersionInfo;

    static AbsolutePath SourceDirectory => RootDirectory / "source";
    static AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    static AbsolutePath TestResultsDirectory => RootDirectory / "TestResults";
    
    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            DeleteDirectory(TestResultsDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target CalculateVersion => _ => _
        .Executes(() =>
        {
            // all the magic happens inside `[OctoVersion]` above.
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(_ => _
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Clean)
        .DependsOn(Restore)
        .Executes(() =>
        {
            Log.Information("Building Octopus Server Extensibility v{Version}", OctoVersionInfo.FullSemVer);

            DotNetBuild(_ => _
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetVersion(OctoVersionInfo.FullSemVer)
                .EnableNoRestore());
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(_ => _
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetNoBuild(true)
                .EnableNoRestore()
                .SetFilter(@"FullyQualifiedName\!~Integration.Tests")
                .SetLoggers("trx")
                .SetResultsDirectory(TestResultsDirectory));
        });

    Target Pack => _ => _
        .DependsOn(CalculateVersion)
        .DependsOn(Compile)
        .DependsOn(Test)
        .Executes(() =>
        {
            Log.Information("Packing Octopus Server Extensibility v{Version}", OctoVersionInfo.FullSemVer);
            
            DotNetPack(_ => _
                .SetProject(Solution)
                .SetVersion(OctoVersionInfo.FullSemVer)
                .SetConfiguration(Configuration)
                .SetOutputDirectory(ArtifactsDirectory)
                .EnableNoBuild()
                .DisableIncludeSymbols()
                .SetVerbosity(DotNetVerbosity.Normal)
                .SetProperty("NuspecProperties", $"Version={OctoVersionInfo.FullSemVer}"));
            
        });

    /// Support plugins are available for:
    /// - JetBrains ReSharper        https://nuke.build/resharper
    /// - JetBrains Rider            https://nuke.build/rider
    /// - Microsoft VisualStudio     https://nuke.build/visualstudio
    /// - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Pack);
}