using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.OrmLite;

namespace UnitofWorkDemo.Core.Repositories
{
    public class RepositoryBase
    {
        protected IDbConnection connection;

        public RepositoryBase(IDbConnection connection)
        {
            this.connection = connection;
        }

    }
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        

        public Repository(IDbConnection connection):base(connection)
        {
        }

        public virtual List<T> GetAll()
        {
            return connection.Select<T>();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return connection.SelectAsync<T>();
        }

        public virtual List<T> Get(Expression<Func<T, bool>> exp)
        {
            return connection.Select<T>(exp);
        }

        public virtual Task<List<T>> GetAsync(Expression<Func<T, bool>> exp)
        {
            return connection.SelectAsync<T>(exp);
        }

        public virtual T GetById(int id)
        {
            var o = connection.SingleById<T>(id);
            return o;
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            var o = connection.SingleByIdAsync<T>(id);
            return o;
        }

        public virtual T GetById(string id)
        {
            var o = connection.SingleById<T>(id);
            return o;
        }

        public virtual Task<T> GetByIdAsync(string id)
        {
            var o = connection.SingleByIdAsync<T>(id);
            return o;
        }
        public bool Save(T o)
        {
            connection.Save<T>(o);
            return true;
        }

        public virtual Task<bool> SaveAsync(T o)
        {
            connection.SaveAsync<T>(o);
            return TaskResult.True;
        }

        public void Delete(int id)
        {
            connection.DeleteById<T>(id);
        }

        public Task DeleteAsync(int id)
        {
            connection.DeleteByIdAsync<T>(id);
            return TaskResult.Finished;
        }

        public void Delete(Expression<Func<T, bool>> exp)
        {
            connection.Delete<T>(exp);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> exp)
        {
            connection.DeleteAsync<T>(exp);
            return TaskResult.Finished;
        }
    }
}