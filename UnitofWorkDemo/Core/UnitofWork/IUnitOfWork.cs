using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWorkDemo.Core.Repositories;

namespace UnitofWorkDemo.Core.UnitofWork
{
    interface IUnitOfWork: IDisposable
    {
        IRepository<T> GetGenericRepository<T>() where T: class;
        TRepository GetRepository<TRepository>() where TRepository : class;
        void Commit();
    }
}
