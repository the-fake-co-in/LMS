using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(BookTypeMasterMetadata))]
    public partial class BookTypeMaster
    {
    }

    internal sealed class BookTypeMasterMetadata
    {
        private BookTypeMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "BookType")]
        [Required(ErrorMessage = "Please enter BookType!")]
        public string Type { get; set; }

        [Display(Name = "Price Depreciation (Months)")]
        public Byte PriceDepreciationTime { get; set; }

        [Display(Name = "Price Depreciation Rate")]
        public Byte PriceDepreciationRate { get; set; }

        [Display(Name = "Max. Price Depreciation")]
        public Byte MaxDepreciationRate { get; set; }
        
        [DefaultValue(false)]
        [Display(Name = "Is Deleted?")]
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