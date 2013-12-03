using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        [StringLength(100)]
        public string ModuleName { get; set; }
    }
}
