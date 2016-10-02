using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRWP.ViewModels
{
    public class PlayerCreatedDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        public int PlayerCount { get; set; }
    }
}