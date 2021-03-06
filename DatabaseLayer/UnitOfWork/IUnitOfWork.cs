﻿using DatabaseLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository Repository { get; }
        Task<int> SaveChangesAsync();
    }
}