using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ_HEPSIBURADA.DAL.Mapping;
using OZ_HEPSIBURADA.DATA.Model_Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OZ_HEPSIBURADA.DAL.Context
{
    public class ECommerceContext : IdentityDbContext<ApplicationUser>
    {
        public ECommerceContext()
            : base(Properties.Settings.Default.DbConnection)
        {
        }

        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<Product> ProductTable { get; set; }
        public DbSet<Order> OrderTable { get; set; }
        public DbSet<OrderDetail> OrderDetailTable { get; set; }
        public DbSet<Shipper> ShipperTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderDetailMapping());
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());

            base.OnModelCreating(modelBuilder);
        }
    }
}
