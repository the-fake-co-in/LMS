using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(BookIssueMetadata))]
    public partial class BookIssue
    {
    }

    internal sealed class BookIssueMetadata
    {
        private BookIssueMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Book")]
        [Required(ErrorMessage = "Please select Book!")]
        public Int32 BookId { get; set; }

        [Display(Name = "Issued For")]
        [Required(ErrorMessage = "Please select Issued For!")]
        public Int32 IssuedFor { get; set; }

        [Display(Name = "Issued By")]
        public Int32 IssuedBy { get; set; }

        [Display(Name = "Issued On")]
        public DateTime IssuedOn { get; set; }

        [Display(Name = "Received By")]
        public Int32 ReceivedBy { get; set; }

        [Display(Name = "Received On")]
        public DateTime ReturnedOn { get; set; }

        public string Remarks { get; set; }

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