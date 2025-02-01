using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MinVer;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[GitHubActions(
    "continuous",
    GitHubActionsImage.Ubuntu2204,
    On = [GitHubActionsTrigger.Push],
    InvokedTargets = [nameof(Push)],
    ImportSecrets = ["BETA_NUGET_API_KEY"],
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

    [MinVer]
    readonly MinVer MinVer;

    [Parameter]
    readonly string ReleaseNugetApiKey;

    [Parameter]
    readonly string BetaNugetApiKey;

    [Parameter]
    readonly string BetaNugetSource = "https://f.feedz.io/bld/beta/nuget/index.json";

    readonly AbsolutePath OutputPath;

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
        .DependsOn(Restore, Clean)
        .Executes(() =>
        {
            DotNetBuild(options => options
                .SetProjectFile(Solution.Bld_LibcameraNet)
                .SetVersionSuffix(GetVersionSuffix())
                .SetConfiguration(Configuration)
                .SetNoRestore(true)
            );
        });

    Target Publish => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetPublish(options => options
                .SetProject(Solution.Bld_LibcameraNet)
                .SetConfiguration(Configuration)
                .SetVersionSuffix(GetVersionSuffix())
                .SetOutput(OutputPath)
                .SetNoRestore(true)
                .SetNoBuild(true));
        });

    Target Push => _ => _
        .DependsOn(Publish)
        .Executes(() =>
        {
            var packages = OutputPath.GlobFiles("*.nupkg");
            DotNetNuGetPush(options => options
                .SetApiKey(BetaNugetApiKey)
                .SetSource(BetaNugetSource));
        });

    private string GetVersionSuffix()
    {
        if (IsLocalBuild)
        {
            return "local";
        }

        return MinVer.MinVerPreRelease;
    }
}
