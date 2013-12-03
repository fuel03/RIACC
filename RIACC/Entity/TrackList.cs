using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class TrackList
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(20)]
        //AutoGen " TR-00000-yyyy "
        public string TrackNumber { get; set; }

        [Required]
        public int DRId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PreparedBy { get; set; }

        [StringLength(150)]
        public string RecievedBy { get; set; }

        [StringLength(100)]
        public string DeliveredBy { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [DefaultValue(false)]
        public bool Deleted {get;set;}

        public virtual ICollection<TrackListDetail> TrackListDetail { get; set; }
    }
}
