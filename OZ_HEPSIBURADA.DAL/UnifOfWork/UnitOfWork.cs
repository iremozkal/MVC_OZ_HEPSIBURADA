using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ_HEPSIBURADA.DAL.Repository;
using OZ_HEPSIBURADA.DAL.Context;

namespace OZ_HEPSIBURADA.DAL.UnifOfWork
{
    // The unit of work class serves one purpose: 
    // to make sure that when you use multiple repositories, they share a single database context. 
    // That way, when a unit of work is complete you can call the SaveChanges method 
    // on that instance of the context and be assured that all related changes will be coordinated. 
    // All that the class needs is a Save method and a property for each repository. 
    // Each repository property returns a repository instance that has been instantiated 
    // using the same database context instance as the other repository instances.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceContext DB;

        public UnitOfWork(ECommerceContext _DB)
        {
            DB = _DB;
        }

        public int SaveChanges()
        {
            return DB.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(DB);
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
