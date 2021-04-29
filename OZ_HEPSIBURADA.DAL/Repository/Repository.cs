using OZ_HEPSIBURADA.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceContext DB;
        private readonly DbSet<T> createdTable;

        public Repository(ECommerceContext _db)
        {
            DB = _db;
            createdTable = DB.Set<T>();
        }

        public IQueryable<T> GetAllEntity()
        {
            return createdTable;        // IQueryable instead of List to increase the performance.
        }

        public T GetEntityById(int id)
        {
            return createdTable.Find(id);
        }

        public void Insert(T Entity)
        {
            DB.Entry(Entity).State = EntityState.Added;
            createdTable.Add(Entity);	// It's saved on the ram.
            // DB.SaveChanges();		// We will do this on UOW after all our operations are finished, not at every step.
        }

        public void Update(T Entity)
        {
            createdTable.Attach(Entity);
            DB.Entry(Entity).State = EntityState.Modified;
        }

        public void Delete(T Entity)
        {
            DB.Entry(Entity).State = EntityState.Deleted;
            createdTable.Remove(Entity);
        }
    }
}
