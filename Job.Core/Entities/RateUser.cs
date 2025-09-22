using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Core.Entities
{
    public class RateUser
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string RaterId { get; set; }
        public virtual AppUser Rater { get; set; }
        public string rateeId { get; set; }
        public virtual AppUser ratee { get; set; }
    }
}
