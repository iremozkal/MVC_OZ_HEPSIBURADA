using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OZ_HEPSIBURADA.DAL.UnifOfWork;

namespace OZ_HEPSIBURADA.WEBUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork IUOW)
            : base(IUOW)
        {
        }

        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
