using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class AuditTrail
    {
        [Key]
        public long AuditId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(25)]
        public string TableName { get; set; }

        [Required]
        public int TransactionId { get; set; }

        [Required]
        [StringLength(50)]
        //Indicate whether the user saved/deleted/updated the transaction
        public string Remarks { get; set; }        
    }
}
