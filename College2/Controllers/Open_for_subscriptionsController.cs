using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using College2.Models;

namespace College2.Controllers
{
    public class Open_for_subscriptionsController : Controller
    {
        private DBCollege db = new DBCollege();

        // GET: Open_for_subscriptions
        public ActionResult Index()
        {
            var open_for_subscriptions = db.open_for_subscriptions.Include(o => o.Cities).Include(o => o.cours);
            return View(open_for_subscriptions.ToList());
        }

        // GET: Open_for_subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            open_for_subscriptions open_for_subscriptions = db.open_for_subscriptions.Find(id);
            if (open_for_subscriptions == null)
            {
                return HttpNotFound();
            }
            return View(open_for_subscriptions);
        }

        // GET: Open_for_subscriptions/Create
        public ActionResult Create()
        {
            ViewBag.City = new SelectList(db.Cities, "Id", "Name");
            ViewBag.course = new SelectList(db.courses, "id", "name");
            return View();
        }

        // POST: Open_for_subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,course,status,dateStart,dateEnd,limitSubscriptions,City")] open_for_subscriptions open_for_subscriptions)
        {
            if (ModelState.IsValid)
            {
                db.open_for_subscriptions.Add(open_for_subscriptions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City = new SelectList(db.Cities, "Id", "Name", open_for_subscriptions.City);
            ViewBag.course = new SelectList(db.courses, "id", "name", open_for_subscriptions.course);
            return View(open_for_subscriptions);
        }

        // GET: Open_for_subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            open_for_subscriptions open_for_subscriptions = db.open_for_subscriptions.Find(id);
            if (open_for_subscriptions == null)
            {
                return HttpNotFound();
            }
            ViewBag.City = new SelectList(db.Cities, "Id", "Name", open_for_subscriptions.City);
            ViewBag.course = new SelectList(db.courses, "id", "name", open_for_subscriptions.course);
            return View(open_for_subscriptions);
        }

        // POST: Open_for_subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,course,status,dateStart,dateEnd,limitSubscriptions,City")] open_for_subscriptions open_for_subscriptions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(open_for_subscriptions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City = new SelectList(db.Cities, "Id", "Name", open_for_subscriptions.City);
            ViewBag.course = new SelectList(db.courses, "id", "name", open_for_subscriptions.course);
            return View(open_for_subscriptions);
        }

        // GET: Open_for_subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            open_for_subscriptions open_for_subscriptions = db.open_for_subscriptions.Find(id);
            if (open_for_subscriptions == null)
            {
                return HttpNotFound();
            }
            return View(open_for_subscriptions);
        }

        // POST: Open_for_subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            open_for_subscriptions open_for_subscriptions = db.open_for_subscriptions.Find(id);
            db.open_for_subscriptions.Remove(open_for_subscriptions);
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
