using System.ComponentModel.DataAnnotations;

namespace Project.Apis.Controllers
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool isCompany { get; set; }
        public bool isUser { get; set; }
    }
}
