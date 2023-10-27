using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisasterPOEApp.Data;
using DisasterPOEApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisasterPOEApp.Controllers
{
    public class ResourceAllocationsController : Controller
    {
        private DisasterPOEAppContext db = new DisasterPOEAppContext();

        

        // GET: ResourceAllocations
        public ActionResult Index()
        {
            return View(db.ResourceAllocation.ToList());
        }

        // GET: ResourceAllocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceAllocation resourceAllocation = db.ResourceAllocation.Find(id);
            if (resourceAllocation == null)
            {
                return HttpNotFound();
            }
            return View(resourceAllocation);
        }

        // GET: ResourceAllocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DisasterId,MoneyDonationId,AmountAllocated,Description,AllocationDate")] ResourceAllocation resourceAllocation)
        {
            if (ModelState.IsValid)
            {
                db.ResourceAllocation.Add(resourceAllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceAllocation);
        }

        // GET: ResourceAllocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceAllocation resourceAllocation = db.ResourceAllocation.Find(id);
            if (resourceAllocation == null)
            {
                return HttpNotFound();
            }
            return View(resourceAllocation);
        }

        // POST: ResourceAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DisasterId,MoneyDonationId,AmountAllocated,Description,AllocationDate")] ResourceAllocation resourceAllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceAllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceAllocation);
        }

        // GET: ResourceAllocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceAllocation resourceAllocation = db.ResourceAllocation.Find(id);
            if (resourceAllocation == null)
            {
                return HttpNotFound();
            }
            return View(resourceAllocation);
        }

        // POST: ResourceAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceAllocation resourceAllocation = db.ResourceAllocation.Find(id);
            db.ResourceAllocation.Remove(resourceAllocation);
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


        public IActionResult AllocateMoney()
        {
            ViewData["Disasters"] = new SelectList(db.Disasters, "Id", "Location");
            ViewData["AvailableMoneyDonations"] = new SelectList(db.MoneyDonations.Where(d => d.amount > 0), "id", "amount");
            return (IActionResult)View();
        }

        [HttpPost]
        public IActionResult AllocateMoney(int DisasterId, int MoneyDonationId, string Description)
        {
            if (ModelState.IsValid)
            {
                var amountAllocated = db.MoneyDonations
                    .Where(d => d.id == MoneyDonationId)
                    .Select(d => d.amount)
                    .FirstOrDefault();

                if (amountAllocated > 0)
                {
                    var allocation = new ResourceAllocation
                    {
                        DisasterId = DisasterId,
                        MoneyDonationId = MoneyDonationId,
                        Description = Description,
                        AmountAllocated = amountAllocated,
                        AllocationDate = DateTime.Now
                    };

                    // Update the MoneyDonation to set the Amount to 0
                    var moneyDonation = db.MoneyDonations.Find(MoneyDonationId);
                    if (moneyDonation != null)
                    {
                        moneyDonation.amount = 0;
                    }

                    db.ResourceAllocation.Add(allocation);
                    db.SaveChanges();

                    return (IActionResult)RedirectToAction("Index"); // Redirect to a page of your choice
                }
            }

            // Handle validation errors and return to the allocation form
            ViewData["Disasters"] = db.Disasters.ToList();
            ViewData["AvailableMoneyDonations"] = db.MoneyDonations.Where(d => d.amount > 0).ToList();
            return (IActionResult)View();
        }
    }
}
