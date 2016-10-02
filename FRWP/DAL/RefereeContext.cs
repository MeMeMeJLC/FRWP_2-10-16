using FRWP.Models;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}