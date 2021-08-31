using System;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    readonly Configuration Configuration = Configuration.Release;

    [Solution] readonly Solution Solution;

    [OctoVersion] readonly OctoVersionInfo OctoVersionInfo;

    static AbsolutePath SourceDirectory => RootDirectory / "source";
    static AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    static AbsolutePath PublishDirectory => RootDirectory / "publish";
    static AbsolutePath LocalPackagesDir => RootDirectory / ".." / "LocalPackages";

    Target Clean => _ => _
                         .Before(Restore)
                         .Executes(() =>
                                   {
                                       SourceDirectory.GlobDirectories("**/bin", "**/obj", "**/TestResults").ForEach(DeleteDirectory);
                                       EnsureCleanDirectory(ArtifactsDirectory);
                                       EnsureCleanDirectory(PublishDirectory);
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
                                         Logger.Info("Building Octopus Server Extensibility v{0}", OctoVersionInfo.FullSemVer);

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
                                                      .SetFilter(@"FullyQualifiedName\!~Integration.Tests"));
                                  });

    Target Pack => _ => _
                        .DependsOn(Test)
                        .Produces(ArtifactsDirectory / "*.nupkg")
                        .Executes(() =>
                                  {
                                      Logger.Info("Packing Octopus Server Extensibility v{0}", OctoVersionInfo.FullSemVer);

                                      // This is done to pass the data to github actions
                                      Console.Out.WriteLine($"::set-output name=semver::{OctoVersionInfo.FullSemVer}");
                                      Console.Out.WriteLine($"::set-output name=prerelease_tag::{OctoVersionInfo.PreReleaseTagWithDash}");

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

    Target CopyToLocalPackages => _ => _
                                       .OnlyWhenStatic(() => IsLocalBuild)
                                       .TriggeredBy(Pack)
                                       .Executes(() =>
                                                 {
                                                     EnsureExistingDirectory(LocalPackagesDir);
                                                     ArtifactsDirectory.GlobFiles("*.nupkg")
                                                                       .ForEach(package =>
                                                                                {
                                                                                    CopyFileToDirectory(package, LocalPackagesDir);
                                                                                });
                                                 });

    Target OutputPackagesToPush => _ => _
                                        .DependsOn(Pack)
                                        .Executes(() =>
                                                  {
                                                      var artifactPaths = ArtifactsDirectory.GlobFiles("*.nupkg")
                                                                                            .NotEmpty()
                                                                                            .Select(p => p.ToString());

                                                      Console.WriteLine($"::set-output name=packages_to_push::{string.Join(',', artifactPaths)}");
                                                  });

    Target Default => _ => _
                          .DependsOn(OutputPackagesToPush);

    /// Support plugins are available for:
    /// - JetBrains ReSharper        https://nuke.build/resharper
    /// - JetBrains Rider            https://nuke.build/rider
    /// - Microsoft VisualStudio     https://nuke.build/visualstudio
    /// - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Default);
}