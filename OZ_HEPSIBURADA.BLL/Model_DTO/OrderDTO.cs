using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.BLL.Model_DTO
{
    public class OrderDTO
    {
        public int DTOId { get; set; }
        public int DTOProductCount { get; set; }
        public decimal DTOTotalPrice { get; set; }
    }
}
