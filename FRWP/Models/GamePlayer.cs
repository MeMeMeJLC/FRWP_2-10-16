using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FRWP.Models
{
    public class GamePlayer
    {
        public int GamePlayerID { get; set; }
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public bool IsStartingSubstitute { get; set; }
        public bool IsCaptain { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
    }
}