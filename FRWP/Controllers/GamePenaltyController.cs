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
    public class GamePenaltyController : Controller
    {
        private RefereeContext db = new RefereeContext();

        // GET: GamePenalty
        public ActionResult Index()
        {
            var gamePenalties = db.GamePenalties.Include(g => g.GamePlayer).Include(g => g.PenaltyType);
            return View(gamePenalties.ToList());
        }

        // GET: GamePenalty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePenalty gamePenalty = db.GamePenalties.Find(id);
            if (gamePenalty == null)
            {
                return HttpNotFound();
            }
            return View(gamePenalty);
        }

        // GET: GamePenalty/Create
        public ActionResult Create()
        {
            ViewBag.GamePlayerID = new SelectList(db.GamePlayers, "GamePlayerID", "GamePlayerID");
            ViewBag.PenaltyCode = new SelectList(db.PenaltyTypes, "Code", "Description");
            return View();
        }

        // POST: GamePenalty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PenaltyID,PenaltyCode,GamePlayerID,TimePenaltyOccurred")] GamePenalty gamePenalty)
        {
            if (ModelState.IsValid)
            {
                db.GamePenalties.Add(gamePenalty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GamePlayerID = new SelectList(db.GamePlayers, "GamePlayerID", "GamePlayerID", gamePenalty.GamePlayerID);
            ViewBag.PenaltyCode = new SelectList(db.PenaltyTypes, "Code", "Description", gamePenalty.PenaltyCode);
            return View(gamePenalty);
        }

        // GET: GamePenalty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePenalty gamePenalty = db.GamePenalties.Find(id);
            if (gamePenalty == null)
            {
                return HttpNotFound();
            }
            ViewBag.GamePlayerID = new SelectList(db.GamePlayers, "GamePlayerID", "GamePlayerID", gamePenalty.GamePlayerID);
            ViewBag.PenaltyCode = new SelectList(db.PenaltyTypes, "Code", "Description", gamePenalty.PenaltyCode);
            return View(gamePenalty);
        }

        // POST: GamePenalty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PenaltyID,PenaltyCode,GamePlayerID,TimePenaltyOccurred")] GamePenalty gamePenalty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamePenalty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GamePlayerID = new SelectList(db.GamePlayers, "GamePlayerID", "GamePlayerID", gamePenalty.GamePlayerID);
            ViewBag.PenaltyCode = new SelectList(db.PenaltyTypes, "Code", "Description", gamePenalty.PenaltyCode);
            return View(gamePenalty);
        }

        // GET: GamePenalty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePenalty gamePenalty = db.GamePenalties.Find(id);
            if (gamePenalty == null)
            {
                return HttpNotFound();
            }
            return View(gamePenalty);
        }

        // POST: GamePenalty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GamePenalty gamePenalty = db.GamePenalties.Find(id);
            db.GamePenalties.Remove(gamePenalty);
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
