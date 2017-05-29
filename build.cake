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

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////
var publishDir = "./publish";
var localPackagesDir = "../LocalPackages";
var artifactsDir = "./artifacts";
var assetDir = "./BuildAssets";
var globalAssemblyFile = "./source/Solution Items/VersionInfo.cs";
var solutionToBuild = "./source/OctopusServerExtensibility.sln";
var fileToPublish = "./source/Server.Extensibility/bin/Release/net451/Octopus.Server.Extensibility.dll";
var coreFileToPublish = "./source/Server.Extensibility/bin/Release/net451/Octopus.Server.Extensibility.Core.dll";
var odcmFileToPublish = "./source/DataCenterManager.Extensibility/bin/Release/netcoreapp1.1/Octopus.DataCenterManager.Extensibility.dll";
var odcmCoreFileToPublish = "./source/DataCenterManager.Extensibility/bin/Release/netcoreapp1.1/Octopus.Server.Extensibility.Core.dll";
var cleanups = new List<IDisposable>(); 

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
    if(BuildSystem.IsRunningOnAppVeyor)
        AppVeyor.UpdateBuildVersion(gitVersionInfo.NuGetVersion);

    Information("Building Octopus.Server.Extensibility v{0}", nugetVersion);
});

Teardown(context =>
{
    Information("Cleaning up");
    foreach(var item in cleanups)
        item.Dispose();

    Information("Finished running tasks.");
});

//////////////////////////////////////////////////////////////////////
//  PRIVATE TASKS
//////////////////////////////////////////////////////////////////////

Task("__Default")
    .IsDependentOn("__Clean")
    .IsDependentOn("__Restore")
    .IsDependentOn("__UpdateAssemblyVersionInformation")
    .IsDependentOn("__Build")
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
    .Does(() => DotNetCoreRestore("source"));
	
Task("__UpdateAssemblyVersionInformation")
    .Does(() =>
{
    cleanups.Add(new AutoRestoreFile(globalAssemblyFile));

	GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = true,
        UpdateAssemblyInfoFilePath = globalAssemblyFile
    });

    Information("AssemblyVersion -> {0}", gitVersionInfo.AssemblySemVer);
    Information("AssemblyFileVersion -> {0}", $"{gitVersionInfo.MajorMinorPatch}.0");
    Information("AssemblyInformationalVersion -> {0}", gitVersionInfo.InformationalVersion);
});

Task("__Build")
    .IsDependentOn("__UpdateAssemblyVersionInformation")
    .Does(() =>
{
    DotNetCoreBuild("./source", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"/p:Version={nugetVersion}")
    });
});

Task("__Pack")
    .Does(() => {
        var nugetPackDir = Path.Combine(publishDir, "nuget");
        var nuspecFile = "Octopus.Server.Extensibility.nuspec";
        
		CreateDirectory(nugetPackDir);
        CopyFileToDirectory(Path.Combine(assetDir, nuspecFile), nugetPackDir);
		CopyFileToDirectory(fileToPublish, nugetPackDir);
		CopyFileToDirectory(coreFileToPublish, nugetPackDir);		

        NuGetPack(Path.Combine(nugetPackDir, nuspecFile), new NuGetPackSettings {
            Version = nugetVersion,
            OutputDirectory = artifactsDir
        });

		var odcmNugetPackDir = Path.Combine(publishDir, "odcm");
        var odcmNuspecFile = "Octopus.DataCenterManager.Extensibility.nuspec";

		CreateDirectory(odcmNugetPackDir);
        CopyFileToDirectory(Path.Combine(assetDir, odcmNuspecFile), odcmNugetPackDir);
		CopyFileToDirectory(odcmFileToPublish, odcmNugetPackDir);
		CopyFileToDirectory(odcmCoreFileToPublish, odcmNugetPackDir);		

        NuGetPack(Path.Combine(odcmNugetPackDir, odcmNuspecFile), new NuGetPackSettings {
            Version = nugetVersion,
            OutputDirectory = artifactsDir
        });

});


Task("__Publish")
    .WithCriteria(BuildSystem.IsRunningOnTeamCity)
    .Does(() =>
{
    NuGetPush($"{artifactsDir}/Octopus.Server.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
		Source = "https://octopus.myget.org/F/octopus-dependencies/api/v3/index.json",
		ApiKey = EnvironmentVariable("MyGetApiKey")
	});

	NuGetPush($"{artifactsDir}/ODCM.Server.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
		Source = "https://octopus.myget.org/F/octopus-dependencies/api/v3/index.json",
		ApiKey = EnvironmentVariable("MyGetApiKey")
	});

    if (gitVersionInfo.PreReleaseLabel == "")
    {
        NuGetPush($"{artifactsDir}/Octopus.Server.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = EnvironmentVariable("NuGetApiKey")
        });
		
        NuGetPush($"{artifactsDir}/ODCM.Server.Extensibility.{nugetVersion}.nupkg", new NuGetPushSettings {
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
    CopyFileToDirectory(Path.Combine(artifactsDir, $"Octopus.Server.Extensibility.{nugetVersion}.nupkg"), localPackagesDir);
	CopyFileToDirectory(Path.Combine(artifactsDir, $"Octopus.DataCenterManager.Extensibility.{nugetVersion}.nupkg"), localPackagesDir);
});

private class AutoRestoreFile : IDisposable
{
	private byte[] _contents;
	private string _filename;
	public AutoRestoreFile(string filename)
	{
		_filename = filename;
		_contents = IO.File.ReadAllBytes(filename);
	}

	public void Dispose() => IO.File.WriteAllBytes(_filename, _contents);
}

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("Default")
    .IsDependentOn("__Default");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////
RunTarget(target);
