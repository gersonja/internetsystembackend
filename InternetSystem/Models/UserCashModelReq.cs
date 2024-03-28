using System.ComponentModel.DataAnnotations;

namespace InternetSystem.Models
{
    public class UserCashModelReq
    {

        [Required(ErrorMessage = "The field is required")]
       
        public int UserUserid { get; set; }

        [Required(ErrorMessage = "The field is required")]
       
        public int CashCashid { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public int Gestorid { get; set; }
    }
}
