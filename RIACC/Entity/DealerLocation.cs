using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class DealerLocation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public int LocationId { get; set; }
        
    }
}
