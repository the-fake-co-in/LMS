using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(BookCodeMasterMetadata))]
    public partial class BookCodeMaster
    {
    }

    internal sealed class BookCodeMasterMetadata
    {
        private BookCodeMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Book")]
        [Required(ErrorMessage = "Please select Book!")]
        public Int32 BookId { get; set; }

        [Display(Name = "BookCode")]
        [Required(ErrorMessage = "Please enter BookCode!")]
        public String BookCode { get; set; }
        
        [DefaultValue(false)]
        [Display(Name = "Is Issued?")]
        public Boolean IsIssued { get; set; }
        
        [DefaultValue(false)]
        [Display(Name = "Is Lost?")]
        public Boolean IsLost { get; set; }
        
        [DefaultValue(false)]
        [Display(Name = "Is Damaged?")]
        public Boolean IsDamaged { get; set; }
        
        [DefaultValue(false)]
        [Display(Name = "Is Deleted?")]
        public Boolean IsDeleted { get; set; }

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