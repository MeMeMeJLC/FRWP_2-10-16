using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FRWP.Models;

namespace FRWP.DAL
{
    public class RefereeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RefereeContext>
    {
        protected override void Seed(RefereeContext context)
        {
            var players = new List<Player>
            {
            new Player{JerseyNumber=5, FirstMidName="Carson",LastName="Alexander",DateCreated=DateTime.Parse("2016-09-01"), TeamID=1},
            new Player{JerseyNumber=15, FirstMidName="Carl",LastName="Alan",DateCreated=DateTime.Parse("2016-01-01"), TeamID=1},
            new Player{JerseyNumber=23, FirstMidName="Bob",LastName="Jones",DateCreated=DateTime.Parse("2016-09-13"), TeamID=1},
            new Player{JerseyNumber=3, FirstMidName="David",LastName="Smith",DateCreated=DateTime.Parse("2016-09-11"), TeamID=1},
            new Player{JerseyNumber=14, FirstMidName="Steve",LastName="Quant",DateCreated=DateTime.Parse("2016-09-28"), TeamID=1},
            new Player{JerseyNumber=33, FirstMidName="John",LastName="Xi",DateCreated=DateTime.Parse("2016-08-01"), TeamID=2},
            new Player{JerseyNumber=22, FirstMidName="Samuel",LastName="Cook",DateCreated=DateTime.Parse("2016-07-01"), TeamID=2},
            new Player{JerseyNumber=11, FirstMidName="Timothy",LastName="Lower",DateCreated=DateTime.Parse("2016-06-01"), TeamID=2},
            new Player{JerseyNumber=10, FirstMidName="Robert",LastName="Plant",DateCreated=DateTime.Parse("2016-05-01"), TeamID=2},
            new Player{JerseyNumber=9, FirstMidName="Jeremy",LastName="Benson",DateCreated=DateTime.Parse("2016-04-01"), TeamID=2},
            new Player{JerseyNumber=1, FirstMidName="Jeff",LastName="Johns",DateCreated=DateTime.Parse("2016-09-14"), TeamID=3},
            new Player{JerseyNumber=12, FirstMidName="Carl",LastName="Giancarlo",DateCreated=DateTime.Parse("2016-09-14"), TeamID=3}
            };
            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();

            var gamePlayers = new List<GamePlayer>
            {
                new GamePlayer {IsCaptain=true, IsStartingSubstitute=false, PlayerID=1, GameID=1 },
                new GamePlayer {IsCaptain=false, IsStartingSubstitute=true, PlayerID=2, GameID=1 },
                new GamePlayer {IsCaptain=false, IsStartingSubstitute=false, PlayerID=3, GameID=1 },
                new GamePlayer {IsCaptain=true, IsStartingSubstitute=false, PlayerID=7, GameID=1 },
                new GamePlayer {IsCaptain=false, IsStartingSubstitute=true, PlayerID=8, GameID=1 },
                new GamePlayer {IsCaptain=false, IsStartingSubstitute=false, PlayerID=9, GameID=1 },
            };
            gamePlayers.ForEach(s => context.GamePlayers.Add(s));
            context.SaveChanges();

            var games = new List<Game>
            {
                new Game { Description="Regional Cup Semi Finals", GameDateTime=DateTime.Parse("2016-10-14") },
                new Game { Description="Regional Cup Finals", GameDateTime=DateTime.Parse("2016-10-21") },
                new Game { Description="Regional Cup Quarter Finals", GameDateTime=DateTime.Parse("2016-10-7") }
            };
            games.ForEach(s => context.Games.Add(s));
            context.SaveChanges();
        }

        
    }
}