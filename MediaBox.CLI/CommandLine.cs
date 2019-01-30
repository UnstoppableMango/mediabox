using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;

namespace MediaBox.CLI
{
    internal static class CommandLine
    {
        public static CommandLineBuilder CreateDefaultBuilder()
            => new CommandLineBuilder()
                .UseDefaults();

        public static CommandLineBuilder RequireUnix(this CommandLineBuilder builder)
            => builder.UseMiddleware(async (context, next) =>
            {
                if (Environment.OSVersion.Platform != PlatformID.Unix)
                {
                    context.Console.Out.WriteLine("Mediabox should be hosted on a Unix platform");
                }
                else
                {
                    await next(context);
                }
            });
    }
}
