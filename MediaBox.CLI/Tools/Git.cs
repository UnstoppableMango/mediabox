using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MediaBox.CLI.Tools
{
    internal static class Git
    {
        public static void Stash() => Execute("stash");

        public static bool ChangedFiles()
            => Execute("diff-tree", "-r", "--name-only", "--no-commit-id", "ORIG_HEAD", "HEAD") <= 0;

        public static int Execute(params string[] args)
        {
            var workDir = AppDomain.CurrentDomain.BaseDirectory;

            var info = new ProcessStartInfo()
            {
                FileName = "git",
                Arguments = string.Join(' ', args),
                WorkingDirectory = workDir
            };

            var process = Process.Start(info);

            process.WaitForExit();

            return process.ExitCode;
        }

        public static bool IsInstalled()
        {
            var path = Environment.GetEnvironmentVariable("PATH");

            var binaryName = Environment.OSVersion.Platform == PlatformID.Unix
                ? "git"
                : "git.exe";

            return path.Split(';').Any(p => File.Exists(Path.Combine(p, binaryName)));
        }
    }
}
