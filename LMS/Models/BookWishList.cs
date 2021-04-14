using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(BookWishListMetadata))]
    public partial class BookWishList
    {
    }

    internal sealed class BookWishListMetadata
    {
        private BookWishListMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter BookName!")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please enter BookDetails!")]
        public string BookDetails { get; set; }

        [DefaultValue(false)]
        [Display(Name="Is Deleted?")]
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