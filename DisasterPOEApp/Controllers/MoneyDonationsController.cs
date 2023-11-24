using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisasterApp.Models;
using DisasterPOEApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DisasterApp.Controllers
{
    public class MoneyDonationsController : Controller
    {

        private DisasterPOEAppContext db = new DisasterPOEAppContext();

        // GET: MoneyDonations
        public ActionResult Index()
        {
            return View(db.MoneyDonations.ToList());
        }

        // GET: MoneyDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyDonation moneyDonation = db.MoneyDonations.Find(id);
            if (moneyDonation == null)
            {
                return HttpNotFound();
            }
            return View(moneyDonation);
        }

        // GET: MoneyDonations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoneyDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,amount,description,date")] MoneyDonation moneyDonation)
        {
            if (ModelState.IsValid)
            {
                db.MoneyDonations.Add(moneyDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moneyDonation);
        }


        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: MoneyDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "id,amount,description,date")] MoneyDonation moneyDonation)
        {
            if (ModelState.IsValid)
            {
                db.MoneyDonations.Add(moneyDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moneyDonation);
        }



        // GET: MoneyDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyDonation moneyDonation = db.MoneyDonations.Find(id);
            if (moneyDonation == null)
            {
                return HttpNotFound();
            }
            return View(moneyDonation);
        }

        // POST: MoneyDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,amount,description,date")] MoneyDonation moneyDonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moneyDonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moneyDonation);
        }

        // GET: MoneyDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyDonation moneyDonation = db.MoneyDonations.Find(id);
            if (moneyDonation == null)
            {
                return HttpNotFound();
            }
            return View(moneyDonation);
        }

        // POST: MoneyDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoneyDonation moneyDonation = db.MoneyDonations.Find(id);
            db.MoneyDonations.Remove(moneyDonation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult TotalDonations()
        {
            decimal totalDonationAmount = db.MoneyDonations.Sum(d => d.amount);
            ViewBag.TotalDonations = totalDonationAmount;
            return View();
        }
    }
    

}
