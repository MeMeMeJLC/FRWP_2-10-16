using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FRWP.Models
{
    public class GamePenalty
    {
        [Key]
        public int PenaltyID { get; set; }
        [ForeignKey("PenaltyType")]
        public string PenaltyCode { get; set; }
        public int GamePlayerID { get; set; }
        [Display(Name = "Time Scored h:mm:ss")]
        public TimeSpan TimePenaltyOccurred { get; set; }

        public virtual GamePlayer GamePlayer { get; set; }
        public virtual PenaltyType PenaltyType { get; set; }
    }
}