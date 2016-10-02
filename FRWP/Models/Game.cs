using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FRWP.Models
{
    public class Game
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Game Number")]
        public int GameID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Description { get; set; }
        public DateTime GameDateTime { get; set; }

       /* [Range(0, 5)]
        public int Credits { get; set; }*/


        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }
}