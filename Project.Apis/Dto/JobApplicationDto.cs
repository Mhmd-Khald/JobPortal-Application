using Job.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Apis.Dto
{
    public class JobApplicationDto
    {
        public DateTime DateApplied { get; set; }
        //public string CvUrl { get; set; }
        public string message { get; set; }
        public IFormFile File { get; set; }
        public string user { get; set; }
        public string AppuserId { get; set; }
        //public int JobId { get; set; }
        public string Job { get; set; }
    }
}
