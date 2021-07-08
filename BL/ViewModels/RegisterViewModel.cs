using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name ="Last name")]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        //[customAttribute] for Email uniqueness
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name ="Confirm password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
