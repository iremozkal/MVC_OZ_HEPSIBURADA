using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_HEPSIBURADA.DATA.Model_Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string DeliveryAddress { get; set; }
        public string InvoiceAddress { get; set; }
    }
}
