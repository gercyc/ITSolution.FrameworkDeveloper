using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSolution.Framework.Web.Administrator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Software Factory";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact-me";

            return View();
        }
    }
}