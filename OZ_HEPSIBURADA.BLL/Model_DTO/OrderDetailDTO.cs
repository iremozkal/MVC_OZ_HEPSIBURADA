using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.BLL.Model_DTO
{
    public class OrderDetailDTO
    {
        public int DTOOrderId { get; set; }
        public int DTOProductId { get; set; }
        public int DTOQuantity { get; set; }
        public decimal DTOTotalPrice { get; set; }
    }
}
