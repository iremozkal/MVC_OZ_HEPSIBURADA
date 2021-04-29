using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllEntity();		// IQueryable instead of List
        T GetEntityById(int id);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(T Entity);              // SoftDelete and HardDelete will be decided on Business Layer.
    }
}
