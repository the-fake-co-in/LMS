using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using System;

namespace LMS.Models
{
    [MetadataType(typeof(UserMasterMetadata))]
    public partial class UserMaster
    {
    }

    internal sealed class UserMasterMetadata
    {
        private UserMasterMetadata()
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

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Required(ErrorMessage = "Please enter Password!")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

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
        [Display(Name="Is User Blocked?")] 
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
        [Display(Name = "Is Deleted?")]
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
    }
}