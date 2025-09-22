using System.ComponentModel.DataAnnotations;

namespace Project.Apis.Dto
{
    public class ForgetPasswordDto
    {
        [EmailAddress(ErrorMessage ="InvalidEmailAddress")]
        [Required (ErrorMessage ="Email Required")]
        public string Email { get; set; }
    }
}
