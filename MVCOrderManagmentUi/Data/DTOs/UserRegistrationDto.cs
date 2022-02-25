using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOrderManagmentUi.Data.DTOs
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20)]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "The password and confirm Password do not match")]
        public string ConfrimPassword { get; set; }
    }
}
