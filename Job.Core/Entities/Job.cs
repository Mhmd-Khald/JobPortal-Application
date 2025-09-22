using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Entities
{
    public class Jobs
    {
        public int Id { get; set; }
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
        public string disabledJob { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string WorkPlace { get; set; }
        [Required]
        public string Experience { get; set; }
        public AppUser User { get; set; }
        public string AppUserId { get; set; }
        public virtual ICollection<JobApplication> JobAppications { get; set; } = new HashSet<JobApplication>();

    }
}
