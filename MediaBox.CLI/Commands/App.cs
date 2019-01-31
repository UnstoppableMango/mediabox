using System;
using System.Collections.Generic;
using System.Text;
using McMaster.Extensions.CommandLineUtils;
using MediaBox.CLI.Data;

namespace MediaBox.CLI.Commands
{
    [Command]
    internal class App
    {
        private readonly IRepository _repository;

        public App(IRepository repository)
        {
            _repository = repository;
        }

        [Option("--d-user")]
        public string DaemonUsername { get; set; }

        [Option("--d-pass")]
        public string DaemonPassword { get; set; }

        [Option("--vpn-user")]
        public string PiaUsername { get; set; }

        [Option("--vpn-pass")]
        public string PiaPassword { get; set; }

        [Option("--download-dir")]
        public string DownloadDirectory { get; set; }

        [Option("--tv-dir")]
        public string TvDirectory { get; set; }

        [Option("--anime-dir")]
        public string AnimeDirectory { get; set; }

        [Option("--movie-dir")]
        public string MovieDirectory { get; set; }

        [Option("--music-dir")]
        public string MusicDirectory { get; set; }

        public void OnExecute()
        {

        }
    }
}
