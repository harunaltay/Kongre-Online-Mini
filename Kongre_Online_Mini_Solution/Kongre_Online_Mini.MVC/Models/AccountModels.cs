using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kongre_Online_Mini.MVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is required.")]
        [Display(Name = "User name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "User name is required.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)] // burası 6 idi, 3 yaptım!
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match!")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage = "User name is required!")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Old password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New password is required!")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)] // burası 6 idi!
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match!")]
        public string ConfirmPassword { get; set; }

    }



}