using System.ComponentModel.DataAnnotations;

namespace Project.Apis.Dto
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [RegularExpression(("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
                    , ErrorMessage = "Has minimum 8 characters in length,At least one uppercase English letter,At least one lowercase English letter,At least one digit,At least one special character")]
        [Compare("Password" , ErrorMessage = "ConfirmPassword Didnt Match")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
