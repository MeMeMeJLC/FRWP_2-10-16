using FRWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FRWP.ViewModels
{
    public class GameIndexData
    {
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<GamePlayer> GamePlayers { get; set; }
    }
}