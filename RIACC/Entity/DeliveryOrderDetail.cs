using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
   public class DeliveryOrderDetail
    {
       [Key]
       public int DRDetailId { get; set; }

       [Required]
       public int DRId { get; set; }

       [Required]       
       public int POId { get; set; }

       [Required]
       public int PODetailId { get; set; }

       public virtual DeliveryOrder DeliveryOrder { get; set; }
    }
}
