using System.CommandLine.Builder;

namespace MediaBox.CLI.Update
{
    internal static class CommandLineBuilderExtensions
    {
        public static CommandLineBuilder RegisterUpdateCommand(this CommandLineBuilder builder)
        {
            return builder;
        }
    }
}
