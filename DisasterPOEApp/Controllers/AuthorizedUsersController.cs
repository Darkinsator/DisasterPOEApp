using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisasterPOEApp.Data;
using DisasterPOEApp.Models;

namespace DisasterPOEApp.Controllers
{
    public class AuthorizedUsersController : Controller
    {
        private DisasterPOEAppContext db = new DisasterPOEAppContext();

        // GET: AuthorizedUsers
        public ActionResult Index()
        {
            return View(db.AuthorizedUsers.ToList());
        }

        // GET: AuthorizedUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizedUser authorizedUser = db.AuthorizedUsers.Find(id);
            if (authorizedUser == null)
            {
                return HttpNotFound();
            }
            return View(authorizedUser);
        }

        // GET: AuthorizedUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        void ConnectionString()
        {
            con.ConnectionString = "Server=tcp:disaster-servernew.database.windows.net,1433;Initial Catalog=dbdisaster;Persist Security Info=False;User ID=jason.blankenberg@capaciti.org.za;Password=RaSeNsHuRiKeN18#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication='Active Directory Password';";
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(AuthorizedUser obj)
        {
            ViewBag.Test = "1";
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from AuthorizedUsers where UserName = '" + obj.UserName + "'and password = '" + obj.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {

                return View("/Views/AuthorizedUsers/Menu.cshtml");
            }
            else
            {

                return View();
            }



        }

        // POST: AuthorizedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")] AuthorizedUser authorizedUser)
        {
            if (ModelState.IsValid)
            {
                db.AuthorizedUsers.Add(authorizedUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorizedUser);
        }

        // GET: AuthorizedUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizedUser authorizedUser = db.AuthorizedUsers.Find(id);
            if (authorizedUser == null)
            {
                return HttpNotFound();
            }
            return View(authorizedUser);
        }

        // POST: AuthorizedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password")] AuthorizedUser authorizedUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorizedUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorizedUser);
        }

        // GET: AuthorizedUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizedUser authorizedUser = db.AuthorizedUsers.Find(id);
            if (authorizedUser == null)
            {
                return HttpNotFound();
            }
            return View(authorizedUser);
        }

        // POST: AuthorizedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorizedUser authorizedUser = db.AuthorizedUsers.Find(id);
            db.AuthorizedUsers.Remove(authorizedUser);
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
