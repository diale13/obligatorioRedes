using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace ServerAdmin.Models
{
    public class UserRegisterModel
    {
        [Required]
        [StringLength(100)]
        public string NickName { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]     
        [MembershipPassword]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }


        public override string ToString()
        {
            return $"New user created with nick: {NickName}, Email: {Email} , and name {FirstName} {LastName}";
        }

    }
}