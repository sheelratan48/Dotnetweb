using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using formewb.Models;

namespace formewb.Controllers
{
    public class StudentidsController : Controller
    {
        private WebappdbEntities db = new WebappdbEntities();

        // GET: Studentids
        public ActionResult Index()
        {
            return View(db.Studentids.ToList());
        }

        // GET: Studentids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentid studentid = db.Studentids.Find(id);
            if (studentid == null)
            {
                return HttpNotFound();
            }
            return View(studentid);
        }

        // GET: Studentids/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studentids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Age,Branch,Roll_no_")] Studentid studentid)
        {
            if (ModelState.IsValid)
            {
                db.Studentids.Add(studentid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentid);
        }

        // GET: Studentids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentid studentid = db.Studentids.Find(id);
            if (studentid == null)
            {
                return HttpNotFound();
            }
            return View(studentid);
        }

        // POST: Studentids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Age,Branch,Roll_no_")] Studentid studentid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentid);
        }

        // GET: Studentids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentid studentid = db.Studentids.Find(id);
            if (studentid == null)
            {
                return HttpNotFound();
            }
            return View(studentid);
        }

        // POST: Studentids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studentid studentid = db.Studentids.Find(id);
            db.Studentids.Remove(studentid);
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
