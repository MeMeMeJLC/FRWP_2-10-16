using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FRWP.Models
{
    public class Player
    {
        public int ID { get; set; }
        public int JerseyNumber { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime DateCreated { get; set; }
        public int TeamID { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        //public virtual Team Team { get; set; }
    }
}