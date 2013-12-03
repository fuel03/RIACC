using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class PurchaseOrderDetail
    {
        [Key]
        public int PODetailId { get; set; }

        [Required]
        public int POId { get; set; }

        [Required]
        [StringLength(15)]
        //Auto Generated Format ( INV-000000 )
        public string InventoryNumber { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
