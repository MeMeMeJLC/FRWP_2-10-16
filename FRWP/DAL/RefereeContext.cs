﻿using FRWP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FRWP.DAL
{
    public class RefereeContext : DbContext
    {
        public RefereeContext() : base("RefereeContext")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<Player> Players { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<PenaltyType> PenaltyTypes { get; set; }
        //public DbSet<GamePenalty> GamePenalties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public System.Data.Entity.DbSet<FRWP.Models.GamePenalty> GamePenalties { get; set; }
    }
}