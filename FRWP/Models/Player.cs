using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FRWP.Models
{
    public class Player
    {
        public int ID { get; set; }
        [Column("Jersey Number")]

        public int JerseyNumber { get; set; }
        [StringLength(50 , MinimumLength =1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "First and Middle names can't be longer than 50 characters")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Join Date")]
        public DateTime DateCreated { get; set; }
        //[ForeignKey("Team")]
        public int TeamID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        //public virtual Team Team { get; set; }
    }
}