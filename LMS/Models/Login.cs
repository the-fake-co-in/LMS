using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

    public class ForgotUserName
    {
        [Required(ErrorMessage = "Please enter Email!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                                    ErrorMessage = "Please enter valid Email Address!")]
        public string Email { get; set; }
    }

    public class ForgotPassword
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please enter UserName!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Email!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                                    ErrorMessage = "Please enter valid Email Address!")]
        public string Email { get; set; }
    }

    public class ChangePassword
    {
        [Key]
        public int UserId { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password!")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Confirmation Password!")]
        public string ConfirmPassword { get; set; }
    }
}