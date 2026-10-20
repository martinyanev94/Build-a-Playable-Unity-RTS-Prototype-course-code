#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace RTSPrototype
{
    public static class BuildSystem
    {
        private static readonly string[] releaseScenes =
        {
            "Assets/Scenes/Level01.unity",
            "Assets/Scenes/GameUI.unity"
        };

        private static readonly string[] debugScenes =
        {
            "Assets/Scenes/Playground.unity",
            "Assets/Scenes/GameUI.unity"
        };

        private static void Build(BuildTarget target, BuildOptions options,
            string[] scenes, string outputPath)
        {
            string directory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            var build = new BuildPlayerOptions
            {
                scenes = scenes,
                locationPathName = outputPath,
                target = target,
                options = options
            };

            BuildReport report = BuildPipeline.BuildPlayer(build);
            BuildSummary summary = report.summary;
            if (summary.result == BuildResult.Succeeded)
                Debug.Log($"Build succeeded: {summary.outputPath}");
            else
                Debug.LogError($"Build failed: {summary.totalErrors} errors");
        }

        [MenuItem("Build/RTS/Debug macOS")]
        private static void BuildDebugMacOS()
        {
            Build(BuildTarget.StandaloneOSX, BuildOptions.Development,
                debugScenes, "Builds/RTSPrototype-debug/RTSPrototype.app");
        }

        [MenuItem("Build/RTS/Release macOS")]
        private static void BuildReleaseMacOS()
        {
            Build(BuildTarget.StandaloneOSX, BuildOptions.None,
                releaseScenes, "Builds/RTSPrototype-macOS/RTSPrototype.app");
        }

        [MenuItem("Build/RTS/Release Windows")]
        private static void BuildReleaseWindows()
        {
            Build(BuildTarget.StandaloneWindows64, BuildOptions.None,
                releaseScenes, "Builds/RTSPrototype-Windows/RTSPrototype.exe");
        }
    }
}
#endif
