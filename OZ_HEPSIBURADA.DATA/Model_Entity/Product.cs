using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DATA.Model_Entity
{
    public class Product : BaseClass
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // 1 Product has 1 Category
        public int CategoryId { get; set; }
        public Category CategoryOfProduct { get; set; }

        // 1 Product has M OrderDetails
        public List<OrderDetail> OrderDetailsOfProduct { get; set; }
    }
}
