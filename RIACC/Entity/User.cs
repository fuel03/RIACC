using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RIACC.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please input Username.")]
        [StringLength(25)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please input Password.")]
        //MAX 25 length -- Cannot imply StringLength due to Encryption
        public string Password { get; set; }

        [Required(ErrorMessage = "Please input First Name.")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please input Last Name.")]
        [StringLength(100)]
        public string LastName { get; set; }
               
        [StringLength(100)]
        public string MiddleName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public DateTime? Expiration { get; set; }

        [DefaultValue(false)]
        public bool IsLocked { get; set; }

        [DefaultValue(false)]
        public bool IsExpired { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public int VoidLoginCount { get; set; }

        public DateTime? LastLogin { get; set; }

        [DefaultValue(false)]
        public bool ChangePasswordRequest { get; set; }
    }
}