using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS.Models
{
    [MetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail
    {
    }

    internal sealed class UserDetailMetadata
    {
        private UserDetailMetadata()
        {
        }

        [Key]
        public int UserId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please enter UserName!")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Email!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                                    ErrorMessage = "Please enter valid Email Address!")]
        public string Email { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Please select Role!")]
        public Int16 RoleId { get; set; }

        [Display(Name = "Failed Login Attempt")]
        public Byte FailAttempt { get; set; }

        [DefaultValue(false)]
        [Display(Name = "IsBlocked?")]
        public bool IsBlocked { get; set; }

        [Display(Name = "Block Reason")]
        public bool BlockReason { get; set; }

        [Display(Name = "Last Login Date")]
        [DefaultValue(Utilities.Utility.MAX_DATETIME)]
        DateTime LastLoginDate { get; set; }

        [Display(Name = "Last LogOut Date")]
        [DefaultValue(Utilities.Utility.MAX_DATETIME)]
        DateTime LastLogoutDate { get; set; }

        [DefaultValue(false)]
        [Display(Name = "IsDeleted?")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Created By")]
        public Int32 CreatedBy { get; set; }

        [Display(Name = "Created On")]
        [DefaultValue(Utilities.Utility.MAX_DATETIME)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public Int32 ModifiedBy { get; set; }

        [Display(Name = "Modified On")]
        [DefaultValue(Utilities.Utility.MAX_DATETIME)]
        public DateTime ModifiedOn { get; set; }

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