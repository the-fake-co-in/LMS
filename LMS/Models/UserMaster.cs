using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LMS.Models
{
    public class UserMaster
    {
        public int UserId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please enter UserName!")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password!")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter Password!")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }  

        [Required(ErrorMessage = "Please enter Email!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                                    ErrorMessage = "Please enter valid Email Address!")]
        public string Email { get; set; }
    }
}