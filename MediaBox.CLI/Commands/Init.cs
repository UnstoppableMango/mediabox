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

            var username = Environment.UserName;

            console.WriteLine($"Path is {path}");
            console.WriteLine($"Username is {username}");

            console.WriteLine($"OS is {Environment.OSVersion}");

            console.WriteLine("Executing id");

            Tool.Run("id", "-un");
        }
    }
}
