using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdminToolsModel.Account
{
    [Table("Account")]
    public class LoginUser
    {
        [Key]
        public virtual int Id { get; set; }

        [Required(ErrorMessage ="User Name Null")]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public virtual string UserName { get; set; }

        [Required(ErrorMessage = "Password Null")]
        [MaxLength(20)]
        public virtual string Password { get; set; }

        [Required]
        [Range(0,2)]
        public virtual int RoleId { get; set; }
    }    
}