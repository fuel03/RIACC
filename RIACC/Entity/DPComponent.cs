using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class DPComponent
    {
        [Key]
        public int DPId { get; set; }

        [Required]
        [StringLength(20)]
        //AutoGen " DP-00000-yyyy "
        public string DPNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PreparedBy { get; set; }

        [Required]
        public int ApprovedBy { get; set; }

        [DefaultValue(true)] //Just in case we need to have an approval system in this module
        public bool Approved { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<DPComponentDetail> DPComponentDetail { get; set; }
    }
}
