using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DATA.Model_Entity
{
	public class OrderDetail : BaseClass
	{
		// 1 OrderDetail has 1 Order
		public int OrderId { get; set; }
		public Order OrderOfDetail { get; set; }

		// 1 Order has 1 Product
		public int ProductId { get; set; }
		public Product ProductOfDetail { get; set; }

		public int Quantity { get; set; }
		public int Discount { get; set; }
	}
}
