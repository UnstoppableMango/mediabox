using System.Diagnostics;

namespace MediaBox.CLI.Tools
{
    public static class Tool
    {
        public static void Run(string name, params string[] args)
        {
            var info = new ProcessStartInfo()
            {
                FileName = name,
                Arguments = string.Join(' ', args),
                //WorkingDirectory
            };

            var process = Process.Start(info);

            process.WaitForExit();
        }
    }
}
