using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using MediaBox.CLI.Config;
using MediaBox.CLI.Update;

namespace MediaBox.CLI
{
    static class Program
    {
        static Task<int> Main(string[] args) => GetCommandLineBuilder().Build().InvokeAsync(args);

        private static CommandLineBuilder GetCommandLineBuilder()
            => CommandLine.CreateDefaultBuilder()
#if !DEBUG
                .RequireUnix()
#endif
                .AddAppCommands()
                .EnablePosixBundling()
                .RegisterWithDotnetSuggest();

        private static CommandLineBuilder AddAppCommands(this CommandLineBuilder builder)
            => builder
                .RegisterConfigCommand()
                .RegisterUpdateCommand();
    }
}
