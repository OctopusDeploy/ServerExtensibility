using System;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Octopus.NukeBuildComponents;

[UnsetVisualStudioEnvironmentVariables]
[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild, IComponentBuild
{
    public string TargetPackageDescription => "Server.ServerExtensibility";

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    public Enumeration Config => IsLocalBuild ? Configuration.Debug : Configuration.Release;

    /// Support plugins are available for:
    /// - JetBrains ReSharper        https://nuke.build/resharper
    /// - JetBrains Rider            https://nuke.build/rider
    /// - Microsoft VisualStudio     https://nuke.build/visualstudio
    /// - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => ((IComponentBuild)x).Default);
}