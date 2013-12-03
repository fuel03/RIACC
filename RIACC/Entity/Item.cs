using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please input Item Code.")]
        [StringLength(100)]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Please input Item Description.")]
        [StringLength(100)]
        public string ItemDescription { get; set; }

        [Required]
        public int UnitId { get; set; }

        public decimal? Price { get; set; }
        
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
