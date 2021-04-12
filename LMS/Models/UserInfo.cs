using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS.Models
{
    [MetadataType(typeof(UserInfoMetadata))]
    public partial class UserInfo
    {
    }

    internal sealed class UserInfoMetadata
    {
        private UserInfoMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "User")]
        public int Userid { get; set; }

        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Please enter FirstName!")]
        public string FirstName { get; set; }

        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Please enter LastName!")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select Gender!")]
        public char Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please select Date of Birth!")]
        [DefaultValue(Utilities.Utility.MAX_DATETIME)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Mobile No.")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter Mobile No.!")]
        public string MobileNo { get; set; }

        [Display(Name = "Home Contact No.")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter Home Contact No.!")]
        public string HomeContactNo { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Please Enter Address Line 1!")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please Enter City!")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please Enter State!")]
        public string State { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please Enter Country!")]
        public string Country { get; set; }

        [Display(Name = "PinCode")]
        [Required(ErrorMessage = "Please Enter PinCode!")]
        public string Pincode { get; set; }

        [Display(Name = "Addmission Date")]
        [Required(ErrorMessage = "Please select Date of Join Date!")]
        [DefaultValue(Utilities.Utility.MAX_DATETIME)]
        public DateTime DateOfJoin { get; set; }
    }
}