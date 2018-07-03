using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitofWorkDemo.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all elements of type T
        /// </summary>
        List<T> GetAll();

        /// <summary>
        /// Async version of GetAll()
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Get elements that comply to the specified criteria
        /// </summary>
        List<T> Get(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Async version of Get()
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        Task<List<T>> GetAsync(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Get an instance of T with the specified id
        /// </summary>
        T GetById(int id);

        /// <summary>
        /// Async version of GetById()
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Get an instance of T with the specified id
        /// </summary>
        T GetById(string id);

        /// <summary>
        /// Async version of GetById()
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// Inserts or updates instance
        /// </summary>
        bool Save(T o);

        /// <summary>
        /// Async version of Save()
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        Task<bool> SaveAsync(T o);

        /// <summary>
        /// Deletes element with specified id
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// Async version of Delete()
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Delete elements that comply to specified criteria
        /// </summary>
        void Delete(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Async version of Delete()
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<T, bool>> exp);
    }
}