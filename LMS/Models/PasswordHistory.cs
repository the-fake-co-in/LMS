using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(PasswordHistoryMetadata))]
    public partial class PasswordHistory
    {
    }

    internal sealed class PasswordHistoryMetadata
    {
        private PasswordHistoryMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "User")]
        public Int32 UserId { get; set; }

        [Display(Name = "Old Password")]
        public String OldPassword { get; set; }

        [Display(Name = "New Password")]
        public String NewPassword { get; set; }

        [Display(Name = "Source for Modification")]
        [DefaultValue("Unknown")]
        public String ModifyingSource { get; set; }

        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}