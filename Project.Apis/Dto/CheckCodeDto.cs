using System.ComponentModel.DataAnnotations;

namespace Project.Apis.Dto
{
    public class CheckCodeDto
    {
        [Required]
         public string verificationcode { get; set; }  
        
       
    }
}
