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
    public class GamePlayerController : Controller
    {
        private RefereeContext db = new RefereeContext();

        // GET: GamePlayer
        public ActionResult Index()
        {
            var gamePlayers = db.GamePlayers.Include(g => g.Game).Include(g => g.Player);
            return View(gamePlayers.ToList());
        }

        // GET: GamePlayer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePlayer gamePlayer = db.GamePlayers.Find(id);
            if (gamePlayer == null)
            {
                return HttpNotFound();
            }
            return View(gamePlayer);
        }

        // GET: GamePlayer/Create
        public ActionResult Create()
        {
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Description");
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "LastName");
            return View();
        }

        // POST: GamePlayer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GamePlayerID,PlayerID,GameID,IsStartingSubstitute,IsCaptain")] GamePlayer gamePlayer)
        {
            if (ModelState.IsValid)
            {
                db.GamePlayers.Add(gamePlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "Description", gamePlayer.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "LastName", gamePlayer.PlayerID);
            return View(gamePlayer);
        }

        // GET: GamePlayer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePlayer gamePlayer = db.GamePlayers.Find(id);
            if (gamePlayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Description", gamePlayer.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "LastName", gamePlayer.PlayerID);
            return View(gamePlayer);
        }

        // POST: GamePlayer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GamePlayerID,PlayerID,GameID,IsStartingSubstitute,IsCaptain")] GamePlayer gamePlayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamePlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Description", gamePlayer.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "LastName", gamePlayer.PlayerID);
            return View(gamePlayer);
        }

        // GET: GamePlayer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePlayer gamePlayer = db.GamePlayers.Find(id);
            if (gamePlayer == null)
            {
                return HttpNotFound();
            }
            return View(gamePlayer);
        }

        // POST: GamePlayer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GamePlayer gamePlayer = db.GamePlayers.Find(id);
            db.GamePlayers.Remove(gamePlayer);
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
