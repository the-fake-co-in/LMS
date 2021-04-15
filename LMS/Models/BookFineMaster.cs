using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using LMS.Utilities;

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
            using (LMSEntities dbEntities = new LMSEntities())
            {
            }
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "BookType")]
        [Required(ErrorMessage = "Please select BookType!")]
        public Byte BookTypeId { get; set; }

        [Display(Name = "FineType")]
        [Required(ErrorMessage = "Please select FineType!")]
        public Byte FineTypeId { get; set; }

        [Display(Name = "Min. Fine (Rs.)")]
        [Required(ErrorMessage = "Please Enter Minimum Fine (Rs.)!")]
        public Int32 LateFeeBaseChargeAmount { get; set; }

        [Display(Name = "Base Fine (% of Book Price)")]
        [Required(ErrorMessage = "Please Enter Base Fine (% of Book Price)!")]
        public Byte LateFeeBaseChargePercent { get; set; }

        [Display(Name = "Late Fee Increase (Rs.)")]
        [Required(ErrorMessage = "Please Enter Late Charge Increase (Rs)!")]
        public Int32 LateFeeIncreaseAmount { get; set; }

        [Display(Name = "Fine Increase (%)")]
        [Required(ErrorMessage = "Please Enter Fine Increase (%)!")]
        public Byte LateFeeIncreasePercentage { get; set; }
        
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