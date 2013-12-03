using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Please input Unit Name.")]
        [StringLength(100)]
        public string UnitName { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

    }
}
