using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Entities
{
    public class JobApplication
    {
        [Required]

        public int Id { get; set; }

        
        [Required]
        public DateTime DateApplied { get; set; }
        public string CvUrl { get; set; }
        public string message { get; set; }
        public AppUser user { get; set; }
        public string AppuserId { get; set; }
        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public virtual Jobs Jobs { get; set; }
    }
}
