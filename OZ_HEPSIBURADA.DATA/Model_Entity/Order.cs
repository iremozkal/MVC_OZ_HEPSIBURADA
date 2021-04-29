using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DATA.Model_Entity
{
    public class Order : BaseClass
    {
        public int OrderId { get; set; }
        public DateTime DeliveryDate { get; set; }

        // 1 Order has 1 ApplicationUser
        public int ApplicationUserId { get; set; }
        public ApplicationUser BuyerOfOrder { get; set; }

        // 1 Order has 1 Shipper
        public int ShipperId { get; set; }
        public Shipper ShipperOfOrder { get; set; }

        // 1 Order has M OrderDetails
        public List<OrderDetail> DetailsOfOrder { get; set; }
    }
}
