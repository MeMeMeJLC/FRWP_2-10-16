using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRWP.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        [Display(Name="Team Name")]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}