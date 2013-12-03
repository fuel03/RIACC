using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ModuleId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
