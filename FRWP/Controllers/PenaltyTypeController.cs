using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FRWP.DAL;
using FRWP.Models;

namespace FRWP.Controllers
{
    public class PenaltyTypeController : Controller
    {
        private RefereeContext db = new RefereeContext();

        // GET: PenaltyType
        public ActionResult Index()
        {
            return View(db.PenaltyTypes.ToList());
        }

        // GET: PenaltyType/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PenaltyType penaltyType = db.PenaltyTypes.Find(id);
            if (penaltyType == null)
            {
                return HttpNotFound();
            }
            return View(penaltyType);
        }

        // GET: PenaltyType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PenaltyType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Description")] PenaltyType penaltyType)
        {
            if (ModelState.IsValid)
            {
                db.PenaltyTypes.Add(penaltyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(penaltyType);
        }

        // GET: PenaltyType/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PenaltyType penaltyType = db.PenaltyTypes.Find(id);
            if (penaltyType == null)
            {
                return HttpNotFound();
            }
            return View(penaltyType);
        }

        // POST: PenaltyType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Description")] PenaltyType penaltyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penaltyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(penaltyType);
        }

        // GET: PenaltyType/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PenaltyType penaltyType = db.PenaltyTypes.Find(id);
            if (penaltyType == null)
            {
                return HttpNotFound();
            }
            return View(penaltyType);
        }

        // POST: PenaltyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PenaltyType penaltyType = db.PenaltyTypes.Find(id);
            db.PenaltyTypes.Remove(penaltyType);
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
