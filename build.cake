//////////////////////////////////////////////////////////////////////
// TOOLS
//////////////////////////////////////////////////////////////////////
#tool "nuget:?package=GitVersion.CommandLine&prerelease"

using Path = System.IO.Path;
using IO = System.IO;
using Cake.Common.Tools;

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var testFilter = Argument("where", "");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////
var publishDir = "./publish";
var localPackagesDir = "../LocalPackages";
var artifactsDir = "./artifacts";

var gitVersionInfo = GitVersion(new GitVersionSettings {
    OutputType = GitVersionOutput.Json
});

var nugetVersion = gitVersionInfo.NuGetVersion;

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////
Setup(context =>
{
    if(BuildSystem.IsRunningOnTeamCity)
        BuildSystem.TeamCity.SetBuildNumber(gitVersionInfo.NuGetVersion);

    Information("Building Octopus.Server.Extensibility v{0}", nugetVersion);
});

Teardown(context =>
{
    Information("Finished running tasks.");
});

//////////////////////////////////////////////////////////////////////
//  PRIVATE TASKS
//////////////////////////////////////////////////////////////////////

Task("__Default")
    .IsDependentOn("__Clean")
    .IsDependentOn("__Restore")
    .IsDependentOn("__Build")
	.IsDependentOn("__Test")
    .IsDependentOn("__Pack")
    .IsDependentOn("__Publish")
    .IsDependentOn("__CopyToLocalPackages");

Task("__Clean")
    .Does(() =>
{
    CleanDirectory(artifactsDir);
    CleanDirectory(publishDir);
    CleanDirectories("./source/**/bin");
    CleanDirectories("./source/**/obj");
});

Task("__Restore")
    .Does(() => DotNetCoreRestore("source", new DotNetCoreRestoreSettings
    {
        ArgumentCustomization = args => args.Append($"/p:Version={nugetVersion}")
    })
);
Task("__Build")
    .Does(() =>
{
    DotNetCoreBuild("./source", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"/p:Version={nugetVersion}")
    });
});

Task("__Test")
    .IsDependentOn("__Build")
    .Does(() => {
		var projects = GetFiles("./source/**/*Tests.csproj");
		foreach(var project in projects)
			DotNetCoreTest(project.FullPath, new DotNetCoreTestSettings
			{
				Configuration = configuration,
				NoBuild = true,
				ArgumentCustomization = args => {
					if(!string.IsNullOrEmpty(testFilter)) {
						args = args.Append("--where").AppendQuoted(testFilter);
					}
					return args.Append("--logger:trx")
                        .Append($"--verbosity normal");
				}
			});
	});

Task("__Pack")
    .Does(() => {
        DotNetCorePack("source", new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = artifactsDir,
            NoBuild = true,
            ArgumentCustomization = args => args.Append($"/p:Version={nugetVersion}")
        });
});


Task("__Publish")
    .WithCriteria(BuildSystem.IsRunningOnTeamCity)
    .Does(() =>
{
    NuGetPush($"{artifactsDir}/Octopus.Client.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
        Source = "https://octopus.myget.org/F/octopus-dependencies/api/v3/index.json",
        ApiKey = EnvironmentVariable("MyGetApiKey")
    });
    
    NuGetPush($"{artifactsDir}/Octopus.Node.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
        Source = "https://octopus.myget.org/F/octopus-dependencies/api/v3/index.json",
        ApiKey = EnvironmentVariable("MyGetApiKey")
    });

    NuGetPush($"{artifactsDir}/Octopus.Server.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
        Source = "https://octopus.myget.org/F/octopus-dependencies/api/v3/index.json",
        ApiKey = EnvironmentVariable("MyGetApiKey")
    });

    if (gitVersionInfo.PreReleaseLabel == "")
    {
        //NuGetPush($"{artifactsDir}/Octopus.Node.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
        //    Source = "https://www.nuget.org/api/v2/package",
        //    ApiKey = EnvironmentVariable("NuGetApiKey")
        //});

        //NuGetPush($"{artifactsDir}/Octopus.Server.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
        //    Source = "https://www.nuget.org/api/v2/package",
        //    ApiKey = EnvironmentVariable("NuGetApiKey")
        //});

        NuGetPush($"{artifactsDir}/Octopus.Client.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = EnvironmentVariable("NuGetApiKey")
        });
    }
});



Task("__CopyToLocalPackages")
    .WithCriteria(BuildSystem.IsLocalBuild)
    .IsDependentOn("__Pack")
    .Does(() =>
{
    CreateDirectory(localPackagesDir);
    CopyFileToDirectory(Path.Combine(artifactsDir, $"Octopus.Client.Extensibility.{nugetVersion}.nupkg"), localPackagesDir);
    CopyFileToDirectory(Path.Combine(artifactsDir, $"Octopus.Node.Extensibility.{nugetVersion}.nupkg"), localPackagesDir);
    CopyFileToDirectory(Path.Combine(artifactsDir, $"Octopus.Server.Extensibility.{nugetVersion}.nupkg"), localPackagesDir);
});

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("Default")
    .IsDependentOn("__Default");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////
RunTarget(target);
