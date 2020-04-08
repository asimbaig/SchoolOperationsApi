using DatabaseLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public UnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}
