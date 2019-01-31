using System.Threading;
using System.Threading.Tasks;
using MediaBox.CLI.Commands;
using MediaBox.CLI.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MediaBox.CLI
{
    internal static class Program
    {
        private static Task<int> Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();

            return GetHostBuilder(args)
                .RunCommandLineApplicationAsync<App>(args, tokenSource.Token);
        }

        private static IHostBuilder GetHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IRepository, LiteDbRepository>();
                });
    }
}
