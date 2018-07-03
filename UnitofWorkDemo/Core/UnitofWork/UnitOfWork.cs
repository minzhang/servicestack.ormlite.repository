using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWorkDemo.Core.Repositories;

namespace UnitofWorkDemo.Core.UnitofWork
{
    class UnitOfWork : IUnitOfWork
    {
        protected IDbConnection connection;
        protected IDbTransaction transaction;
        private bool _disposed;

        public UnitOfWork(IDbConnection connection)
        {
            this.connection = connection;
            this.transaction = connection.OpenTransaction();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(this.connection);
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (this.transaction != null)
                    {
                        this.transaction.Dispose();
                        this.transaction = null;
                    }
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }

    }
}
