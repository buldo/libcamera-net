using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Serilog;
using Serilog.Core;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[GitHubActions(
    "continuous",
    GitHubActionsImage.Ubuntu2204,
    On = [GitHubActionsTrigger.Push],
    InvokedTargets = [nameof(Push)],
    ImportSecrets = ["NUGET_API_KEY_DEV"],
    FetchDepth = 0,
    AutoGenerate = true)]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    public Build()
    {
        OutputPath = RootDirectory / "out";
    }

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution(GenerateProjects = true)]
    readonly Solution Solution;

    [GitVersion(NoFetch = true)]
    readonly GitVersion GitVersion;

    [Parameter]
    readonly string NugetApiKeyRelease;

    [Parameter]
    readonly string NugetApiKeyDev;

    [Parameter]
    readonly string NugetSourceDev = "https://f.feedz.io/bld/beta/nuget/index.json";

    readonly AbsolutePath OutputPath;

    [GitRepository]
    readonly GitRepository Repository;

    private string Version;

    Target PrepareVersion => _ => _
        .Executes(() =>
        {
            Log.Logger.Warning("{@Data}", GitVersion);
            Log.Logger.Warning("{@Data}", Repository);

            var csprojVersion = Solution.Bld_LibcameraNet.GetProperty("VersionPrefix");

            if (IsLocalBuild)
            {
                Version = $"{csprojVersion}-local";
                return;
            }

            var currTag = Repository.Tags.FirstOrDefault();

            if (currTag == null)
            {
                Version = $"{csprojVersion}-{GitVersion.PreReleaseTag}.{GitVersion.BuildMetaData}";
                return;
            }

            if (GitVersion.AssemblySemVer.StartsWith(csprojVersion))
            {
                Version = GitVersion.AssemblySemVer;
                return;
            }

            throw new Exception("Version problem");
        });

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            OutputPath.CreateOrCleanDirectory();
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(options => options
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore, Clean, PrepareVersion)
        .Executes(() =>
        {
            DotNetBuild(options => options
                .SetProjectFile(Solution.Bld_LibcameraNet)
                .SetVersion(Version)
                .SetConfiguration(Configuration)
                .SetNoRestore(true)
            );
        });

    Target Pack => _ => _
        .DependsOn(Compile, PrepareVersion)
        .Executes(() =>
        {
            DotNetPack(options => options
                .SetProject(Solution.Bld_LibcameraNet)
                .SetConfiguration(Configuration)
                .SetVersion(Version)
                .SetOutputDirectory(OutputPath)
                .SetNoBuild(true)
                .SetNoRestore(true));
        });

    Target Push => _ => _
        .DependsOn(Pack)
        .Requires(() => NugetApiKeyDev)
        .Executes(() =>
        {
            var packagePath = OutputPath
                .GlobFiles("*.nupkg")
                .First();
            DotNetNuGetPush(options => options
                .SetApiKey(NugetApiKeyDev)
                .SetSource(NugetSourceDev)
                .SetTargetPath(packagePath));
        });
}

