using OZ_HEPSIBURADA.DAL.UnifOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OZ_HEPSIBURADA.WEBUI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _iuow;

        public BaseController(IUnitOfWork IUOW)
        {
            _iuow = IUOW;
        }
    }
}
