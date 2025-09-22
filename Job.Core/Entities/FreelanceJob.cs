using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Entities
{
    public class FreelanceJob
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ProjectStatue { get; set; }
        public string TimeToComplet { get; set; }
        public DateTime Publised { get; set; }
        public string ProjectDetails { get; set; }
        public string RequiredSkills { get; set; }
        public string Budget { get; set; }
        public AppUser User { get; set; }
        public string AppUserId { get; set; }

    }
}
