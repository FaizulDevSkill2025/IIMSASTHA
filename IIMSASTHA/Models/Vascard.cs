using System.ComponentModel.DataAnnotations;

namespace IIMSASTHA.Models
{
    public class Vascard
    {
        [Key]
        [Display(Name = "ID")]
        public int VascardId { get; set; }

        [Display(Name = "Code")]
        [Required]
        public int Code { get; set; }
        
        [Display(Name = "Image")]
        [StringLength(500)]
        [Required (ErrorMessage = " Please Choose Image")]
        public string ImageUrl{ get; set; }

        [Display(Name = "Signature")]
        [StringLength(500)]
        [Required (ErrorMessage = " Please Choose Signature")]
        public string SigImageUrl { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Designation")]
        [StringLength(100)]
        [Required]
        public string Designation { get; set; }

        [Display(Name = "Blood Group")]
        [StringLength(100)]
        [Required]
        public string Blood { get; set; }

        [Display(Name = "Joining Date")]
        [Required]
        public DateTime JoiningDate { get; set; }

        public string Status { get; set; }
    }
}
