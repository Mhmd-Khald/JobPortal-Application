using Job.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project.Apis.Dto
{
    public class ToPostJobDto
    { 
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string disabledJob { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required]
        public string Requirement { get; set; }
        [Required]
        public DateTime Created { get; set; }=DateTime.Now;
     
        public string City { get; set; }
   
        public string Country { get; set; }
        public string WorkPlace { get; set; }
        

        public string Skill { get; set; }
        [Required(ErrorMessage = "salary Is Required")]
        public int Salary { get; set; }
        [Required(ErrorMessage ="experince Is Required")]
        public string Experience { get; set; }
        public int CompanyId { get; set; } // ForiegnKey
        public string Company { get; set; }
    }
}
