using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.BLL.Model_DTO
{
    public class ProductDTO
    {
        public int DTOId { get; set; }
        public string DTOName { get; set; }
        public string DTODesc { get; set; }
        public int DTOStock { get; set; }
        public decimal DTOPrice { get; set; }
        public int DTOCategoryId { get; set; }
    }
}
