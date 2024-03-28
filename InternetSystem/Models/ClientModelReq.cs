using System.ComponentModel.DataAnnotations;

namespace InternetSystem.Models
{
    public class ClientModelReq
    {
        [Required]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Given ID must be between 10 and 13 characters length")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Given ID must have numbers ONLY")]
        public string Identification { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Given PhoneNumber must be at least 10 characters length")]
        [RegularExpression("^09\\d*$", ErrorMessage = "Given ID must have numbers ONLY and START WITH 09")]
        public string Phonenumber { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Given address must be between 20 and 100 characters length")]
        public string Address { get; set; } = null!;
        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Given reference address must be between 20 and 100 characters length")]
        public string Referenceaddress { get; set; } = null!;
    }
}
