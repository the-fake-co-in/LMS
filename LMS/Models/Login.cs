using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LMS.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please enter UserName!")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password!")]
        public string Password { get; set; }

        public string Email { get; set; }

        public string LoginErrorMessage { get; set; } 
    }

    public class ChangePassword
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please enter UserName!")]
        public string UserName { get; set; }

        [Display(Name = "OTP")]
        [Required(ErrorMessage = "Please enter OTP!")]
        public string OTP { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password!")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Confirmation Password!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string ChangePwdErrMsg { get; set; }
    }
}