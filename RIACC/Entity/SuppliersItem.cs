using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class SuppliersItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int ItemId { get; set; }
        
    }
}
