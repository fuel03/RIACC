using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        
        [Required(ErrorMessage="Please input Location.")]
        [StringLength(50)]
        public string LocationName { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}