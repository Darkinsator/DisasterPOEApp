using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisasterPOEApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Donations()
        {
            ViewBag.Message = "Donations Page";

            return View();
        }
       
        public ActionResult DisasterRequest()
        {
            ViewBag.Message = "Request Resources";

            return View("Views/Disasters/Create.cshtml");
        }
    }
}