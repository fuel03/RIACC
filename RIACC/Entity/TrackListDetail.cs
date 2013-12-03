using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class TrackListDetail
    {
        [Key]
        public int TRDetailId { get; set; }

        [Required]        
        public int TrackId { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int DRDetailId { get; set; }

        public virtual TrackList TrackList { get; set; }
    }
}
