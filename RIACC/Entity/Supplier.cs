using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Please input Supplier Code.")]
        [StringLength(100)]
        public string SupplierCode { get; set; }

        [Required(ErrorMessage = "Please input Supplier Name.")]
        [StringLength(100)]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Please input Supplier's Address.")]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }
        
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
