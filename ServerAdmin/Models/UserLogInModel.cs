using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerAdmin.Models
{
    public class UserLogInModel
    {
        [Required]
        [StringLength(100)]
        public string NickName { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}