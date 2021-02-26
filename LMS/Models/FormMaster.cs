using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [MetadataType(typeof(FormMasterMetadata))]
    public partial class FormMaster
    {
    }

    internal sealed class FormMasterMetadata
    {
        private FormMasterMetadata()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "FormName")]
        [Required(ErrorMessage = "Please enter FormName!")]
        public string Name { get; set; }

        [Display(Name = "FormType")]
        [Required(ErrorMessage = "Please select FormType!")]
        public Byte FormTypeId { get; set; }

        [Required(ErrorMessage = "Please enter FormName!")]
        public String FormName { get; set; }

        [Required(ErrorMessage = "Please enter FormPath!")]
        public String FormPath { get; set; }

        [DefaultValue("0")]
        public String ReadAcces { get; set; }

        [DefaultValue("0")]
        public String WriteAccess { get; set; }

        [DefaultValue("0")]
        public String SpecialReadAccess { get; set; }

        [DefaultValue("0")]
        public String SpecialReadAcces { get; set; }
        
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