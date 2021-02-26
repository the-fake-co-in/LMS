using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(BookFineMasterMetadata))]
    public partial class BookFineMaster
    {
    }

    internal sealed class BookFineMasterMetadata
    {
        private BookFineMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "BookType")]
        [Required(ErrorMessage = "Please select BookType!")]
        public Byte BookTypeId { get; set; }

        [Display(Name = "Late Fee Base (Rs.)")]
        [Required(ErrorMessage = "Please Enter Late Base Charge Fee (Rs.)!")]
        public Byte LateFeeBaseChargeAmount { get; set; }

        [Display(Name = "Late Fee Base (%)")]
        [Required(ErrorMessage = "Please Enter Late Base Charge Fee (%)!")]
        public Byte LateFeeBaseChargePercent { get; set; }

        [Display(Name = "Late Fee Increase (Rs.)")]
        [Required(ErrorMessage = "Please Enter Late Charge Increase (Rs)!")]
        public Byte LateFeeIncreaseAmount { get; set; }

        [Display(Name = "Late Fee Increase (%)")]
        [Required(ErrorMessage = "Please Enter Late Charge Increase (%)!")]
        public Byte LateFeeIncreasePercentage { get; set; }
        
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