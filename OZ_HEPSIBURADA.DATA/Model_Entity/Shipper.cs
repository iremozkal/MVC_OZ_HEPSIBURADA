using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DATA.Model_Entity
{
    public class Shipper : BaseClass
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string PhoneNumber { get; set; }

        // 1 Shipper has M Orders
        public List<Order> OrdersOfShipper { get; set; }
    }
}
