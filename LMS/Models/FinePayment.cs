using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(FinePaymentMetadata))]
    public partial class FinePayment
    {
    }

    internal sealed class FinePaymentMetadata
    {
        private FinePaymentMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "FineType")]
        [Required(ErrorMessage = "Please select Fine!")]
        Byte TypeId { get; set; }

        [Display(Name = "Book")]
        [Required(ErrorMessage = "Please select Book!")]
        public Int32 BookId { get; set; }

        [Display(Name = "Fine Paid By")]
        public Int32 PaidBy { get; set; }

        [Display(Name = "Fine Base Amount")]
        public Int16 BaseAmount { get; set; }

        [Display(Name = "Fine Final Amount")]
        public Int16 FinalAmount { get; set; }

        [Display(Name = "Paid Amount")]
        [Required(ErrorMessage = "Please Fine Payment Amount!")]
        public Int16 PaidAmount { get; set; }

        [Display(Name = "Exemption Amount")]
        public Int16 ExemptionAmount { get; set; }

        [Display(Name = "Payment Receipt No.")]
        [Required(ErrorMessage = "Please Payment Receipt No.!")]
        public string PaymentReceiptNo { get; set; }        

        [Display(Name = "Fine Payment Date")]
        public DateTime PaidOn { get; set; }

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