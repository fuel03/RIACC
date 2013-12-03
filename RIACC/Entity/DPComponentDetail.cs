using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class DPComponentDetail
    {
        [Key]
        public int DPDetailId { get; set; }

        [Required]
        public int DPId { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int DRDetailId { get; set; }

        public virtual DPComponent DPComponent { get; set; }

    }
}
