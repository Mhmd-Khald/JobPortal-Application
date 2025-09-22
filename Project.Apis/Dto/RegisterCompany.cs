using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Apis.Dto
{
    public class RegisterCompany
    {
        public string displayName { get; set; }
        public string Bio { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [RegularExpression(("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
            , ErrorMessage = "Has minimum 8 characters in length,At least one uppercase English letter,At least one lowercase English letter,At least one digit,At least one special character")]
        public string password { get; set; }
        [Compare("password", ErrorMessage = "PasswordNotMatched")]
        public string ConfirmPassword { get; set; }
        public string phoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }


    }
}
