using OZ_HEPSIBURADA.DAL.UnifOfWork;
using OZ_HEPSIBURADA.WEBUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OZ_HEPSIBURADA.WEBUI.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController(IUnitOfWork IUOW)
            : base(IUOW)
        {
        }

        // GET: /Admin/Dashboard/

        public ActionResult Index()
        {
            return View();
        }
    }
}
