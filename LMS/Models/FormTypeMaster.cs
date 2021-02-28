using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(FormTypeMasterMetadata))]
    public partial class FormTypeMaster
    {
    }

    internal sealed class FormTypeMasterMetadata
    {
        private FormTypeMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "FormType")]
        [Required(ErrorMessage = "Please enter FormType!")]
        public string Type { get; set; }

        [Display(Name = "Form Sort Order")]
        [Required(ErrorMessage = "Please enter Form sort order!")]
        public byte DisplayOrder { get; set; }

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