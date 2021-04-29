using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ_HEPSIBURADA.DATA.Model_Entity;
using System.Data.Entity.ModelConfiguration;

namespace OZ_HEPSIBURADA.DAL.Mapping
{
    public class OrderDetailMapping : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapping()
        {
            HasKey(x => x.OrderId);
        }
    }
}
