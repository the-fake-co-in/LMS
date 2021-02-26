using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(BookMasterMetadata))]
    public partial class BookMaster
    {
    }

    internal sealed class BookMasterMetadata
    {
        private BookMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "BookName")]
        [Required(ErrorMessage = "Please enter BookName!")]
        public string Name { get; set; }

        [Display(Name = "BookType")]
        [Required(ErrorMessage = "Please select BookType!")]
        public Byte BookTypeId { get; set; }
        
        [Display(Name = "Author")]
        public Int32 AuthorId { get; set; }
        
        public string Publisher { get; set; }

        [Display(Name = "Published On")]
        public Int32 PublishDate { get; set; }

        public string Edition { get; set; }

        public string ISBN { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter Book Price!")]
        public Int32 price { get; set; }

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