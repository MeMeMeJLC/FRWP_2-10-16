﻿using FRWP.DAL;
using FRWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRWP.Controllers
{
    public class HomeController : Controller
    {
        private RefereeContext db = new RefereeContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<PlayerCreatedDateGroup> data = from player in db.Players
                                                        group player by player.DateCreated into dateGroup
                                                        select new PlayerCreatedDateGroup()
                                                        {
                                                            DateCreated = dateGroup.Key,
                                                            PlayerCount = dateGroup.Count()
                                                        };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}