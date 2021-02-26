using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(AuthorMasterMetadata))]
    public partial class AuthorMaster
    {
    }

    internal sealed class AuthorMasterMetadata
    {
        private AuthorMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "AuthorName")]
        [Required(ErrorMessage = "Please enter AuthorName!")]
        public string Name { get; set; }

        [DefaultValue(false)]
        [Display(Name="Is Deleted?")]
        public bool IsDeleted { get; set; }
        
        [Display(Name = "Created By")]
        public Int32 CreatedBy { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public Int32 ModifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}