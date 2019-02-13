using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using McMaster.Extensions.CommandLineUtils;
using MediaBox.CLI.Tools;

namespace MediaBox.CLI.Commands
{
    [Command(Name = "init")]
    public class Init
    {
        [Argument(0)]
        public string? Path { get; set; }

        public void OnExecute(IConsole console)
        {
            var path = Path ?? Directory.GetCurrentDirectory();

            var username = Tool.Run("id", "-un").ReadToEnd();
            var puid = Tool.Run("id", "-u", username).ReadToEnd();
            var pgid = Tool.Run("id", "-g", username).ReadToEnd();
            var grepOutput = Tool.Run("grep", "docker", "/etc/group").ReadToEnd();
            var dockerGroup = Tool.Run("cut", $"'{grepOutput}'", "-d", ":", "-f", "3").ReadToEnd();

            console.WriteLine(path);
            console.WriteLine(username);
            console.WriteLine(puid);
            console.WriteLine(pgid);
            console.WriteLine(dockerGroup);
        }
    }
}
