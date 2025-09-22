using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace Project.Apis.Dto
{
    public class RegisterUserDto
    {
        public string JobType { get; set; }
        [Required]
      public string DisplayName { get; set; }
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Experience { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string DateOfBirth { get; set; }
        [RegularExpression(("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$") 
            , ErrorMessage = "Has minimum 8 characters in length,At least one uppercase English letter,At least one lowercase English letter,At least one digit,At least one special character")]
        public string password { get; set; }
        [Compare("password" , ErrorMessage ="PasswordNotMatched")]
        public string ConfirmPassword { get; set; }
        public string phoneNumber { get; set; }
    }
}
