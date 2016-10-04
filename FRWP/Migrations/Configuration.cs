namespace FRWP.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FRWP.DAL.RefereeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FRWP.DAL.RefereeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            var players = new List<Player>
            {
            new Player{JerseyNumber=5, FirstMidName="Carson",LastName="Alexander",DateCreated=DateTime.Parse("2016-09-01"), TeamID=1},
            new Player{JerseyNumber=15, FirstMidName="Carl",LastName="Alan",DateCreated=DateTime.Parse("2016-01-01"), TeamID=1},
            new Player{JerseyNumber=23, FirstMidName="Bob",LastName="Jones",DateCreated=DateTime.Parse("2016-09-13"), TeamID=1},
            new Player{JerseyNumber=14, FirstMidName="Steve",LastName="Quant",DateCreated=DateTime.Parse("2016-09-28"), TeamID=1},
            new Player{JerseyNumber=4, FirstMidName="Hiro",LastName="Smith",DateCreated=DateTime.Parse("2016-09-14"), TeamID=1},
            new Player{JerseyNumber=33, FirstMidName="John",LastName="Xi",DateCreated=DateTime.Parse("2016-08-01"), TeamID=2},
            new Player{JerseyNumber=22, FirstMidName="Samuel",LastName="Cook",DateCreated=DateTime.Parse("2016-07-01"), TeamID=2},
            new Player{JerseyNumber=11, FirstMidName="Timothy",LastName="Lower",DateCreated=DateTime.Parse("2016-06-01"), TeamID=2},
            new Player{JerseyNumber=10, FirstMidName="Robert",LastName="Plant",DateCreated=DateTime.Parse("2016-05-01"), TeamID=2},
            new Player{JerseyNumber=9, FirstMidName="Jeremy",LastName="Benson",DateCreated=DateTime.Parse("2016-04-01"), TeamID=2},
            new Player{JerseyNumber=1, FirstMidName="Jeff",LastName="Johns",DateCreated=DateTime.Parse("2016-09-14"), TeamID=3},
            new Player{JerseyNumber=12, FirstMidName="Carl",LastName="Giancarlo",DateCreated=DateTime.Parse("2016-09-14"), TeamID=3}
            };
            players.ForEach(s => context.Players.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var games = new List<Game>
            {
                new Game { Description="Regional Cup Semi Finals", GameDate=DateTime.Parse("2016-10-14"), GameTime=DateTime.Parse("12:00:00")},
                new Game { Description="Regional Cup Finals", GameDate=DateTime.Parse("2016-10-21"), GameTime=DateTime.Parse("14:00:00")},
                new Game { Description="Regional Cup Quarter Finals", GameDate=DateTime.Parse("2016-10-7"), GameTime=DateTime.Parse("16:00:00") }
            };
            games.ForEach(s => context.Games.AddOrUpdate(p => p.Description, s));
            context.SaveChanges();

            var goals = new List<Goal>
            {
                new Models.Goal {GamePlayerID=1, IsOwnGoal=false, TimeScored=new TimeSpan(00,02,23) },
                new Models.Goal {GamePlayerID=4, IsOwnGoal=true, TimeScored=new TimeSpan(00,05,24) },
                new Models.Goal {GamePlayerID=1, IsOwnGoal=false, TimeScored=new TimeSpan(00,22,50) },
                new Models.Goal {GamePlayerID=4, IsOwnGoal=false, TimeScored=new TimeSpan(00,58,12) }

            };
            goals.ForEach(s => context.Goals.AddOrUpdate(p => p.TimeScored, s));
            context.SaveChanges();

            var penaltyTypes = new List<PenaltyType>
            {
                new PenaltyType {Code="Y1", Description="Unsporting behaviour" },
                new PenaltyType {Code="Y2", Description="Dissent by word or action" },
                new PenaltyType {Code="R1", Description="Serious foul play" },
                new PenaltyType {Code="R2", Description="Violent conduct" },
            };
            penaltyTypes.ForEach(s => context.PenaltyTypes.AddOrUpdate(p => p.Code, s));
            context.SaveChanges();

            var gamePlayers = new List<GamePlayer>
            {
                new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Alexander").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals" ).GameID,
                    IsCaptain=true, IsStartingSubstitute=false
                },
                 new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Alan").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals" ).GameID,
                    IsCaptain=false, IsStartingSubstitute=true
                 },
                 new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Jones").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals" ).GameID,
                    IsCaptain=false, IsStartingSubstitute=true
                 },
                 new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Smith").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals" ).GameID,
                    IsCaptain=false, IsStartingSubstitute=true
                 },
                 new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Quant").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals" ).GameID,
                    IsCaptain=false, IsStartingSubstitute=true
                 },
                 new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Xi").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals" ).GameID,
                    IsCaptain=false, IsStartingSubstitute=true
                 },
                 new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Cook").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals" ).GameID,
                    IsCaptain=false, IsStartingSubstitute=true
                 },
                 new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Lower").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals").GameID,
                    IsCaptain=false, IsStartingSubstitute=true
                 },
                new GamePlayer {
                    PlayerID = players.Single(s => s.LastName == "Plant").ID,
                    GameID = games.Single(c => c.Description == "Regional Cup Semi Finals").GameID,
                    IsCaptain=false, IsStartingSubstitute=true                 }
            };

            foreach (GamePlayer e in gamePlayers)
            {
                var gamePlayerInDataBase = context.GamePlayers.Where(
                    s =>
                         s.Player.ID == e.PlayerID &&
                         s.Game.GameID == e.GameID).SingleOrDefault();
                if (gamePlayerInDataBase == null)
                {
                    context.GamePlayers.Add(e);
                }
            }
            context.SaveChanges();

            var penalties = new List<GamePenalty>
            {
                new GamePenalty {PenaltyCode="Y1", GamePlayerID=1, TimePenaltyOccurred = new TimeSpan(0,40,52) },
                new GamePenalty {PenaltyCode="R1", GamePlayerID=3, TimePenaltyOccurred = new TimeSpan(0,57,56) }
            };
            //penalties.ForEach(s => context.GamePenalties.AddOrUpdate(p => p.PenaltyCode, s));
            foreach (GamePenalty e in penalties)
            {
                var penaltyInDataBase = context.GamePenalties.Where(
                    s => s.PenaltyType.Code == e.PenaltyCode).FirstOrDefault();
                if (penaltyInDataBase == null)
                {
                    context.GamePenalties.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
