using System.ComponentModel.DataAnnotations;

namespace InternetSystem.Models
{
    public class UserModelReq
    {
        public int? Userid { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username must be at least 8 characters length, maximum 20")]
        [RegularExpression("^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]+$", ErrorMessage = "Username must have letters and at least 1 number")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters length, maximum 30")]
        [RegularExpression("^(?=.*\\d)(?=.*[A-Z]).{8,30}$", ErrorMessage = "Password must have at least one number and one capital letter")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "RolId is required")]
        public int RolRolid { get; set; }

        [Required(ErrorMessage = "UserStatus is required")]
        public string? UserstatusStatusid { get; set; }
    }
}
