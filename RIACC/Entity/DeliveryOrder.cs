using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class DeliveryOrder
    {
        //Delivery Order / Delivery Receipt
        [Key]
        public int DRId { get; set; }

        [Required]
        [StringLength(20)]
        //AutoGen " DO-00000-yyyy "
        public string DRNumber { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PreparedBy { get; set; }

        public int? ApprovedBy { get; set; }

        [DefaultValue(true)] //Just in case we need to have an approval system in this module
        public bool Approved { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual ICollection<DeliveryOrderDetail> DeliveryOrderDetail { get; set; }
    }
}
