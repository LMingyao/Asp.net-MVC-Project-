using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalWebAppR.Models
{
    public class UserModel
    {
        
        
        public int UserId { get; set ; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to give us your first name!")]
        public string UFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give us your Last name!")]
        public string ULastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to give us your email!")]
        public string UEmail { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You need to give us your Phone Number!")]
        public string UPhoneNumber { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You need to give us your Password!")]
        public string UPassword { get; set; }
        public string UserType { get; set; }
    }
}