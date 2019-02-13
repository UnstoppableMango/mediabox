using System;
using System.Diagnostics;

namespace MediaBox.CLI.Tools
{
    public static class Tool
    {
        public static Process Run(string name, string args)
        {
            var info = new ProcessStartInfo()
            {
                FileName = name,
                Arguments = args,
                //WorkingDirectory
                RedirectStandardOutput = true
            };

            return Process.Start(info);
        }

        public static Process Run(string name, params string[] args)
            => Run(name, string.Join(' ', args));

        public static string ReadToEnd(this Process process)
        {
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output.Replace(Environment.NewLine, string.Empty);
        }
    }
}
