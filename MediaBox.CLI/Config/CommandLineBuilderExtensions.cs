using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using MediaBox.CLI.Tools;

namespace MediaBox.CLI.Config
{
    internal static class CommandLineBuilderExtensions
    {
        private const string NAME = "config";
        private const string DESCRIPTION = "Manage configuration values";

        public static CommandLineBuilder RegisterConfigCommand(this CommandLineBuilder builder)
        {
            var command = GetCommand();

            command.Handler = CommandHandler.Create<IConsole>(Execute);

            builder.AddCommand(command);

            return builder;
        }

        private static Command GetCommand()
        {
            var command = new Command(NAME, DESCRIPTION);

            command.AddAlias("c");

            return command;
        }

        private static void Execute(IConsole console)
        {
            var changedFiles = Git.ChangedFiles();

            console.Out.WriteLine($"Changed Files? {changedFiles}");
        }
    }
}
