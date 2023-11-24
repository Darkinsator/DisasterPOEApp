using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisasterPOEApp.Models;
using DisasterPOEApp.Data;
using Microsoft.AspNetCore.Mvc;
namespace DisasterPOEApp.Controllers
{
    public class HomeController : Controller
    {
        private DisasterPOEAppContext db = new DisasterPOEAppContext();
        public ActionResult Index()
        {
            decimal totalGoodsAmount = 0;
            decimal totalDonationAmount = 0;
            //totalGoodsAmount = db.GoodsDonations.Sum(b => b.items);
            //totalDonationAmount = db.MoneyDonations.Sum(d => d.amount);
            
            ViewBag.TotalGoodsAmount = totalGoodsAmount;
            ViewBag.TotalDonations = totalDonationAmount;
            
            return View(db.ResourceAllocation.ToList());
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