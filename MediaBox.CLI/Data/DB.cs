using System;
using System.Collections.Generic;
using System.Text;

namespace MediaBox.CLI.Data
{
    internal static class DB
    {
        private static readonly IRepository _repo = new LiteDbRepository();


    }
}
