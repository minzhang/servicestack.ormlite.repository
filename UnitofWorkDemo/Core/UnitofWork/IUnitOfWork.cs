﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWorkDemo.Core.Repositories;

namespace UnitofWorkDemo.Core.UnitofWork
{
    interface IUnitOfWork: IDisposable
    {
        IRepository<T> GetRepository<T>() where T: class;
        void Commit();
    }
}
