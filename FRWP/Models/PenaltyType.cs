using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRWP.Models
{
    public class PenaltyType
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}