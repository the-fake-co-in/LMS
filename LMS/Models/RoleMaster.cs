using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(RoleMasterMetadata))]
    public partial class RoleMaster
    {
    }

    internal sealed class RoleMasterMetadata
    {
        private RoleMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "RoleName")]
        [Required(ErrorMessage = "Please enter RoleName!")]
        public string Name { get; set; }

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