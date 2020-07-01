using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerAdmin.Models
{
    public class RatingModel
    {
        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }
        
        [Required]
        [Range(1,10, ErrorMessage = "Select a rating between 1 and 10")]
        public int Rating { get; set; }
    }
}