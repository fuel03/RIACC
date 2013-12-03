using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class PurchaseOrder
    {
        [Key]
        public int POId { get; set; }

        [Required]
        [StringLength(20)]
        //AutoGen " PO-00000-yyyy "
        public string PONumber { get; set; }
        [Required]
        public int SupplierId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal SubTotalAmount { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public int PreparedBy { get; set; }

        [Required]
        public int ApprovedBy { get; set; }

        [DefaultValue(false)]
        public bool Approved { get; set; }

        public double? Discount { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
