using OZ_HEPSIBURADA.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DAL.UnifOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IRepository<T> GetRepository<T>() where T : class;
    }
}
