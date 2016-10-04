using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FRWP.Models
{
    public class Goal
    {
        public int ID { get; set; }
        public bool IsOwnGoal { get; set; }
        [ForeignKey("GamePlayer")]
        public int GamePlayerID { get; set; }
        //[DataType(DataType.)]
        [Display(Name = "Time Scored h:mm:ss")]
        public TimeSpan TimeScored { get; set; }

        public virtual GamePlayer GamePlayer { get; set; }
    }
}