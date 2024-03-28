using System.ComponentModel.DataAnnotations;

namespace InternetSystem.Models
{
    public class CashModelReq
    {
     
        [Required(ErrorMessage = "Cash description is required")]
        [StringLength(50)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cash status is required")]
        [StringLength(1)]
        [RegularExpression("^[A-Z]{1}", ErrorMessage = "The state should only have one letter")]
        public string Active { get; set; }           
        
  
    }
}
