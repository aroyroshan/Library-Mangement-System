using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMgmts.Controllers
{
    public class LibraryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}