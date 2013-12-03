using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class Dealer
    {
        [Key]
        public int DealerId { get; set; }

        [Required(ErrorMessage = "Please input Dealer Code.")]
        [StringLength(50)]
        public string DealerCode { get; set; }

        [Required(ErrorMessage = "Please input Dealer Name.")]
        [StringLength(100)]
        public string DealerName { get; set; }

        [Required(ErrorMessage = "Please input Dealer's Address.")]
        [StringLength(500)]
        public string Address { get; set; }
                
        [StringLength(100)]
        public string ContactPerson { get; set; }        

        [StringLength(50)]
        public string ContactNumber { get; set; }
        
        [StringLength(20)]
        public string TIN { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
