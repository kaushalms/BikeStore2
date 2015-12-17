using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Customer
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Email ID is required")]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}