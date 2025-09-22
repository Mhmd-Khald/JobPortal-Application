using Job.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project.Apis.Dto
{
    public class JobToReturnDto
    {
        public bool HasApplied { get; set; }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string PictureUrl { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string AppUserId { get; set; }
        [Required]
        public string user { get; set; }

        //public string TokenValue { get; set; }
        public int IsCompanyOrNot { get; set; }

    }
}