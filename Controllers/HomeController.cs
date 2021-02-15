using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gm554016.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "I'm Gabe, and I'll be working on this site this semester.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Gabriel J. Morrison";

            return View();
        }
    }
}