using Job.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project.Apis.Dto
{
    public class ToReurnJobDetails
    {
        public int Id { get; set; }
        public string WorkPlace { get; set; }

        public string PictureUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required]
        public string Requirement { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Skill { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Experience { get; set; }
        public string user { get; set; } // ForiegnKey
        public String UserId { get; set; }
    }
}
