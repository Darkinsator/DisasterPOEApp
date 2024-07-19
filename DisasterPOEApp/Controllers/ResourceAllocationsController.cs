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
            PopulateDropdownLists();
            return View();
        }

        // POST: ResourceAllocations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DisasterId,AmountAllocated,Resource,ResourceAmount,AllocationDate")] ResourceAllocation resourceAllocation)
        {
            if (ModelState.IsValid)
            {
                // Set MoneyDonationId based on the selected amount
                var selectedAmount = int.Parse(Request["AmountAllocated"]);
                var moneyDonation = db.MoneyDonations.FirstOrDefault(d => d.amount == selectedAmount);
                resourceAllocation.MoneyDonationId = moneyDonation.id;

                // Set GoodsDonationId based on the selected resource
                var selectedResource = Request["Resource"];
                var goodsDonation = db.GoodsDonations.FirstOrDefault(d => d.description == selectedResource);
                resourceAllocation.GoodsDonationId = goodsDonation.id;

                // Add the resource allocation to the database
                db.ResourceAllocation.Add(resourceAllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropdownLists();
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
            PopulateDropdownLists();
            return View(resourceAllocation);
        }

        // POST: ResourceAllocations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DisasterId,MoneyDonationId,GoodsDonationId,AmountAllocated,Resource,ResourceAmount,AllocationDate")] ResourceAllocation resourceAllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceAllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropdownLists();
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

        private void PopulateDropdownLists()
        {
            ViewBag.DisasterList = new SelectList(db.Disasters, "Id", "Location");
            ViewBag.AmountAllocatedList = new SelectList(db.MoneyDonations, "amount", "amount");
            ViewBag.ResourceList = new SelectList(db.GoodsDonations, "description", "description");
        }
    }
}