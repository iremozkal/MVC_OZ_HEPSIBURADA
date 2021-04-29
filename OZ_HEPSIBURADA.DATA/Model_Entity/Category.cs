using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DATA.Model_Entity
{
    public class Category : BaseClass
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }

        // 1 Category has M Products
        public List<Product> ProductsOfCategory { get; set; }
    }
}
