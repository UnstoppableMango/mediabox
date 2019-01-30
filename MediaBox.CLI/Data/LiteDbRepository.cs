using System;
using System.Collections.Generic;
using LiteDB;

namespace MediaBox.CLI.Data
{
    internal class LiteDbRepository : IRepository, IDisposable
    {
        private readonly LiteDatabase _db = new LiteDatabase("cli.db");

        public IEnumerable<T> Get<T>()
        {
            return _db.GetCollection<T>().FindAll();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }

                disposedValue = true;
            }
        }
        
        ~LiteDbRepository()
        {
            Dispose(false);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
