using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DisasterPOEApp.Data;
using DisasterPOEApp.Models;

namespace DisasterPOEApp.Controllers
{
    public class DisastersController : Controller
    {
        private DisasterPOEAppContext db = new DisasterPOEAppContext();

        // GET: Disasters
        public ActionResult Index()
        {
            return View(db.Disasters.ToList());
        }

        // GET: Disasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            return View(disaster);
        }

        // GET: Disasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disasters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Location,AidType")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                db.Disasters.Add(disaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disaster);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Disasters/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "Id,StartDate,EndDate,Location,AidType")] Disaster disaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Disasters.Add(disaster);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Help is on the way!";
                    return View("/Views/Home/Menu.cshtml");
                }
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details
                System.Diagnostics.Debug.WriteLine("DbUpdateException: " + ex.Message);
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                // Add a user-friendly error message
                ModelState.AddModelError("", "An error occurred while saving the disaster. Please try again later.");
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
            }

            return View(disaster);
        }

        // GET: Disasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            return View(disaster);
        }

        // POST: Disasters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Location,AidType")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disaster);
        }

        // GET: Disasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            return View(disaster);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disaster disaster = db.Disasters.Find(id);
            db.Disasters.Remove(disaster);
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
    }
}